﻿using System.Windows;
using Music.ViewModel.PlayerCommandsBar;
using Unity;

namespace Music.View.PlayerCommandsBar
{
    public partial class PlayerCommandsBar
    {
        public PlayerCommandsBar()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public PlayerCommandsBar(PlayerCommandsBarViewModel playerCommandsBarViewModel)
        {
            InitializeComponent();
            DataContext = playerCommandsBarViewModel;
        }

        #region ShowCoverButton

        public bool IsShowCoverButton
        {
            get => (bool) GetValue(IsShowCoverButtonProperty);
            set => SetValue(IsShowCoverButtonProperty, value);
        }

        public static readonly DependencyProperty IsShowCoverButtonProperty =
            DependencyProperty.Register(
                                        "IsShowCoverButton",
                                        typeof(bool),
                                        typeof(PlayerCommandsBar),
                                        new PropertyMetadata(true, ShowCoverButtonPropertyChanged)
                                       );

        private static void ShowCoverButtonPropertyChanged(DependencyObject                   d,
                                                           DependencyPropertyChangedEventArgs e
        )
        {
            if (d is PlayerCommandsBar thisPlayerCommandsBar &&
                e.OldValue is bool oldValue                  &&
                e.NewValue is bool newValue)
            {
            }
        }

        #endregion




        public bool IsShowAlbumTitle
        {
            get => (bool) GetValue(IsShowAlbumTitleProperty);
            set => SetValue(IsShowAlbumTitleProperty, value);
        }

        public static readonly DependencyProperty IsShowAlbumTitleProperty =
            DependencyProperty.Register(
                       "IsShowAlbumTitle",
                       typeof(bool),
                       typeof(PlayerCommandsBar),
                       new PropertyMetadata(true, IsShowAlbumTitlePropertyChanged)
                      );

        private static void IsShowAlbumTitlePropertyChanged(DependencyObject                   d,
                                             DependencyPropertyChangedEventArgs e
        )
        {
            if (d is PlayerCommandsBar thisPlayerCommandsBar             &&
                e.OldValue is bool oldValue &&
                e.NewValue is bool newValue)
            {

            }
        }
    }
}