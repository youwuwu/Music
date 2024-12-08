using System.Windows.Input;

namespace Music
{
    public static class Commands
    {
        public static ICommand MainRegionNavigationCommand { get; set; }

        public static ICommand PlayAlbumCommand { get; set; }


        public static ICommand LoadAlbumCommand { get; set; }

        public static ICommand ShowPlayingSongCommand { get; set; }
        public static ICommand HidePlayingSongCommand { get; set; }
    }
}