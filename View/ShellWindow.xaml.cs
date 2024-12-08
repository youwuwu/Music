using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Prism.Commands;

namespace Music.View
{
    public partial class ShellWindow
    {
        public ShellWindow()
        {
            Commands.ShowPlayingSongCommand = new DelegateCommand(ShowPlayingSong);
            Commands.HidePlayingSongCommand = new DelegateCommand(HidePlayingSong);

            InitializeComponent();
        }

        private TranslateTransform _playingSongTranslateTransform;

        private DoubleAnimation _showingAnimation;

        private void ShowPlayingSong()
        {
            //让 PlayingSong 从窗口最下方滑出
            PlayingSongRegion.Visibility = Visibility.Hidden;

            _playingSongTranslateTransform    ??= new TranslateTransform(0, ActualHeight);
            PlayingSongRegion.RenderTransform =   _playingSongTranslateTransform;

            PlayingSongRegion.Visibility = Visibility.Visible;

            _showingAnimation = new DoubleAnimation(ActualHeight,
                                                    0,
                                                    new Duration(TimeSpan.FromMilliseconds(500)),
                                                    FillBehavior.HoldEnd
                                                   )
                                {
                                    EasingFunction = new ExponentialEase()
                                                     {
                                                         EasingMode = EasingMode.EaseOut
                                                     }
                                };

            _showingAnimation.Completed += ShowingAnimationCompleted;


            _playingSongTranslateTransform.BeginAnimation(TranslateTransform.YProperty,
                                                          _showingAnimation
                                                         );
        }

        private void ShowingAnimationCompleted(object    sender,
                                               EventArgs e
        )
        {
            _playingSongTranslateTransform.Y =  0;
            _showingAnimation.Completed      -= ShowingAnimationCompleted;
            _showingAnimation                =  null;
            _playingSongTranslateTransform?.BeginAnimation(TranslateTransform.YProperty,
                                                           null
                                                          );
        }


        private DoubleAnimation _hidingAnimation;

        private void HidePlayingSong()
        {
            _playingSongTranslateTransform    ??= new TranslateTransform(ActualHeight, 0);
            PlayingSongRegion.RenderTransform =   _playingSongTranslateTransform;

            _hidingAnimation = new DoubleAnimation(0,
                                                   ActualHeight,
                                                   new Duration(TimeSpan.FromMilliseconds(500)),
                                                   FillBehavior.HoldEnd
                                                  )
                               {
                                   EasingFunction = new ExponentialEase()
                                                    {
                                                        EasingMode = EasingMode.EaseOut
                                                    }
                               };

            _hidingAnimation.Completed += _hidingAnimation_Completed;

            _playingSongTranslateTransform.BeginAnimation(TranslateTransform.YProperty,
                                                          _hidingAnimation
                                                         );
        }

        private void _hidingAnimation_Completed(object    sender,
                                                EventArgs e
        )
        {
            _hidingAnimation.Completed -= _hidingAnimation_Completed;
            _hidingAnimation           =  null;
            _playingSongTranslateTransform?.BeginAnimation(TranslateTransform.YProperty,
                                                           null
                                                          );

            PlayingSongRegion.Visibility = Visibility.Collapsed;
        }
    }
}