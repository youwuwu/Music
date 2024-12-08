using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Timers;
using JetBrains.Annotations;
using NAudio.Wave;
using Music.Player.Enum;

namespace Music.Player
{
    public class WaveDirectSoundPlayer : INotifyPropertyChanged, IDisposable
    {
        public WaveDirectSoundPlayer()
        {
            _timer.Elapsed += _timer_Elapsed;
        }

        private readonly Timer _timer = new(200);

        private void _timer_Elapsed(object           sender,
                                    ElapsedEventArgs e
        )
        {
            OnPropertyChanged(nameof(CurrentTime));
        }


        

        private DirectSoundOut _directSoundOut;
        private DirectSoundOut DirectSoundOut
        {
            get => _directSoundOut;
            set
            {
                _directSoundOut = value;
                UpdatePlayStatus();
            }
        }


        #region AudioFile

        public event EventHandler AudioFileChanged;

        private string _audioFile;


        public string AudioFile
        {
            get => _audioFile;
            set
            {
                if (_audioFile == value)
                {
                    return;
                }

                Stop();

                _audioFile = value;

                FreeAudioFileReader();
                InitAudioFileReader();

                AudioFileChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion


        private void InitAudioFileReader()
        {
            if (!string.IsNullOrWhiteSpace(AudioFile))
            {
                if (File.Exists(AudioFile))
                {
                    AudioFileReader = new AudioFileReader(AudioFile)
                                      {
                                          Volume = IsMute ? 0 : Volume
                                      };
                }
                else
                {
                    throw new FileNotFoundException("指定的音频文件不存在.", AudioFile);
                }
            }
        }

        private void FreeAudioFileReader()
        {
            if (AudioFileReader == null)
            {
                return;
            }

            AudioFileReader.Dispose();
            AudioFileReader = null;
        }

        private AudioFileReader _audioFileReader;

        private AudioFileReader AudioFileReader
        {
            get => _audioFileReader;
            set
            {
                if (!ReferenceEquals(_audioFileReader, value))
                {
                    _audioFileReader = value;

                    if (DirectSoundOut != null)
                    {
                        FreeDirectSoundOut();
                    }
                    else
                    {
                        UpdatePlayStatus();
                    }
                }
            }
        }



        public Guid DeviceGuid { get; set; }


        public TimeSpan TotalTime => AudioFileReader?.TotalTime ?? TimeSpan.Zero;

        public TimeSpan CurrentTime
        {
            get
            {
                if (DirectSoundOut == null || AudioFileReader == null)
                {
                    return TimeSpan.Zero;
                }


                return (DirectSoundOut.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : AudioFileReader.CurrentTime;
            }
            set => SetPositionInMilliseconds(value.TotalMilliseconds);
        }


        public double GetLengthInMilliseconds()
        {
            if (AudioFileReader == null)
            {
                throw new ApplicationException("尚未打开音频文件,无法获取长度.");
            }

            return TimeSpan
                  .FromSeconds(AudioFileReader.Length / (double) AudioFileReader.WaveFormat.AverageBytesPerSecond)
                  .TotalMilliseconds;
        }

        public double GetPositionInMilliseconds()
        {
            if (DirectSoundOut == null || AudioFileReader == null)
            {
                return 0;
            }

            return TimeSpan
                  .FromSeconds(DirectSoundOut.GetPosition() / (double) AudioFileReader.WaveFormat.AverageBytesPerSecond)
                  .TotalMilliseconds;
        }

        public void SetPositionInMilliseconds(double milliseconds)
        {
            if (AudioFileReader == null)
            {
                throw new ApplicationException("尚未打开音频文件,无法设置位置.");
            }

            AudioFileReader.Position = (long) (AudioFileReader.WaveFormat.AverageBytesPerSecond * milliseconds / 1000d);
        }




        public event EventHandler PlayStatusChanged;

        public PlayStatus PlayStatus { get; private set; }


        private void UpdatePlayStatus()
        {
            if (AudioFileReader == null)
            {
                PlayStatus = PlayStatus.None;

                Debug.Print("状态更改为 none (AudioFileReader == null)");

                return;
            }

            if (DirectSoundOut == null)
            {
                PlayStatus = PlayStatus.Stopped;


                Debug.Print("状态更改为 Stopped (DirectSoundOut == null)");

                return;
            }

            PlayStatus = DirectSoundOut.PlaybackState switch
                         {
                             PlaybackState.Playing => PlayStatus.Playing,
                             PlaybackState.Paused  => PlayStatus.Paused,
                             PlaybackState.Stopped => PlayStatus.Stopped,
                             _                     => throw new ArgumentOutOfRangeException()
                         };


            Debug.Print($"状态更改为 {PlayStatus} (PlayStatus.Playing)");
        }



        public event EventHandler VolumeChanged;

        private bool _isMute;
        public bool IsMute
        {
            get => _isMute;
            set
            {
                _isMute = value;

                if (AudioFileReader == null) return;

                if (_isMute)
                {
                    if (AudioFileReader.Volume != 0f)
                    {
                        AudioFileReader.Volume = 0f;
                    }
                }
                else
                {
                    if (Math.Abs(AudioFileReader.Volume - Volume) > 0.0001)
                    {
                        AudioFileReader.Volume = Volume;
                    }
                }
            }
        }


        private float _volume = 1f;

        public float Volume
        {
            get => _volume;
            set
            {
                if (value is > 1f or < 0f)
                {
                    throw new ArgumentOutOfRangeException(nameof(Volume), $"值{value}超出了音量值的取值范围为0~1.");
                }

                _volume = value;

                if (AudioFileReader != null)
                {
                    AudioFileReader.Volume = _volume;
                }

                IsMute = _volume == 0f;

                VolumeChanged?.Invoke(this, EventArgs.Empty);
            }
        }



        public static Dictionary<int, string> InitDevice()
        {
            var result = new Dictionary<int, string>();
            for (var deviceId = 0; deviceId < WaveOut.DeviceCount; deviceId++)
            {
                var capabilities = WaveOut.GetCapabilities(deviceId);

                result.Add(deviceId, capabilities.ProductName);
            }

            return result;
        }



        public event EventHandler PlayStarted;

        public event EventHandler PlayComplete;

        public bool CanPlay =>
            !string.IsNullOrWhiteSpace(AudioFile) &&
            AudioFileReader != null               &&
            PlayStatus      != PlayStatus.Playing;

        public void GetReadyToPlay()
        {
        }
        public void Play()
        {
            if (string.IsNullOrWhiteSpace(AudioFile))
            {
                return;
            }

            FreeDirectSoundOut();
            FreeAudioFileReader();

            InitAudioFileReader();
            InitDirectSoundOut();

            DirectSoundOut.Play();
            Debug.Print("WaveDirectSoundPlayer.play 被调用 ,开始播放");


            _timer.AutoReset = true;
            _timer.Start();

            UpdatePlayStatus();
            PlayStatusChanged?.Invoke(this, EventArgs.Empty);
            PlayStarted?.Invoke(this, EventArgs.Empty);
        }


        private void InitDirectSoundOut()
        {
            DirectSoundOut?.Dispose();

            if (DeviceGuid != Guid.Empty)
            {
                var device = DirectSoundOutManager.PlayDevices.FirstOrDefault(v => v.Guid == DeviceGuid);

                DeviceGuid = device?.Guid ?? Guid.Empty;
            }

            DirectSoundOut = DeviceGuid == Guid.Empty ? new DirectSoundOut() : new DirectSoundOut(DeviceGuid);

            DirectSoundOut.Init(AudioFileReader);

            DirectSoundOut.PlaybackStopped += OnPlaybackStopped;
        }



        public event EventHandler Paused;

        public bool CanPause =>
            DirectSoundOut != null &&
            PlayStatus     == PlayStatus.Playing;

        public void Pause()
        {
            if (DirectSoundOut != null)
            {
                if (DirectSoundOut.PlaybackState == PlaybackState.Playing)
                {
                    DirectSoundOut.Pause();

                    _timer.Stop();
                    UpdatePlayStatus();
                    PlayStatusChanged?.Invoke(this, EventArgs.Empty);
                    Paused?.Invoke(this, EventArgs.Empty);
                }
            }
        }




        public event EventHandler Resumed;

        public bool CanResume =>
            DirectSoundOut != null &&
            PlayStatus     == PlayStatus.Paused;

        public void Resume()
        {
            if (DirectSoundOut != null)
            {
                if (DirectSoundOut.PlaybackState == PlaybackState.Paused)
                {
                    DirectSoundOut.Play();

                    _timer.AutoReset = true;
                    _timer.Start();
                    UpdatePlayStatus();
                    PlayStatusChanged?.Invoke(this, EventArgs.Empty);
                    Resumed?.Invoke(this, EventArgs.Empty);
                }
            }
        }




        public event EventHandler Stopped;

        public bool CanStop =>
            DirectSoundOut != null               &&
            PlayStatus     != PlayStatus.Stopped &&
            PlayStatus     != PlayStatus.None;

        public void Stop()
        {
            if (DirectSoundOut == null)
            {
                return;
            }

            if (DirectSoundOut.PlaybackState != PlaybackState.Stopped)
            {
                DirectSoundOut.Stop();
                UpdatePlayStatus();
                Stopped?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                UpdatePlayStatus();
            }
        }


        private void OnPlaybackStopped(object           sender,
                                       StoppedEventArgs e
        )
        {
            _timer.Stop();
            UpdatePlayStatus();
            PlayStatusChanged?.Invoke(this, EventArgs.Empty);

            FreeDirectSoundOut();

            //只有在播放完全部的音频时才触发 PlayComplete
            if (AudioFileReader.Length == AudioFileReader.Position)
            {
                PlayComplete?.Invoke(this, EventArgs.Empty);
            }
        }



        public void Dispose()
        {
            FreeDirectSoundOut();
            FreeAudioFileReader();
        }

        private void FreeDirectSoundOut()
        {
            if (DirectSoundOut == null)
            {
                return;
            }

            if (DirectSoundOut.PlaybackState != PlaybackState.Stopped)
            {
                DirectSoundOut.Stop();
            }

            DirectSoundOut.PlaybackStopped -= OnPlaybackStopped;
            DirectSoundOut.Dispose();
            DirectSoundOut = null;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}