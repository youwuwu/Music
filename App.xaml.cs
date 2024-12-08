using System.Windows;
using System.Windows.Media;
using ControlzEx.Theming;
using Music.View;
using Music.View.MainContentPages;
using Music.View.Menu;
using Music.View.PlayerCommandsBar;
using Music.View.PlayingSong;
using Music.View.TitleBar;
using Music.ViewModel;
using Music.ViewModel.MainContentPages;
using Music.ViewModel.Menu;
using Music.ViewModel.PlayerCommandsBar;
using Music.ViewModel.TitleBar;
using Prism.Ioc;
using Prism.Mvvm;

namespace Music
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            var color = Color.FromRgb(31, 211, 182);

            var theme = new Theme(
                                  "Light.PPGreenBlue",
                                  "PPGreenBlue(Light)",
                                  "Light",
                                  "PPGreenBlue",
                                  color,
                                  new SolidColorBrush(color),
                                  false,
                                  false
                                 );

            ThemeManager.Current.AddTheme(theme);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var navigationCatalog = new NavigationCatalog();
            containerRegistry.RegisterInstance(navigationCatalog);

            containerRegistry.RegisterSingleton<FakeDataCreator>();

            containerRegistry.RegisterSingleton<PlayerCommandsBarViewModel>();

            containerRegistry.RegisterForNavigation<Recommend>(navigationCatalog.Recommend);
            containerRegistry.RegisterForNavigation<MusicHall>(navigationCatalog.MusicHall);
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register<ShellWindow, ShellWindowViewModel>();
            ViewModelLocationProvider.Register<PlayerCommandsBar, PlayerCommandsBarViewModel>();
            ViewModelLocationProvider.Register<PlayingSong, PlayerCommandsBarViewModel>();

            ViewModelLocationProvider.Register<Menus, MenusViewModel>();
            ViewModelLocationProvider.Register<TitleBar, TitleBarViewModel>();

            ViewModelLocationProvider.Register<Recommend, RecommendViewModel>();
            ViewModelLocationProvider.Register<MusicHall, MusicHallViewModel>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }
    }
}