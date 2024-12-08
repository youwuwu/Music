using MvvmHelpers;

namespace Music.ViewModel.Menu
{
    public class MenuItemViewModel : BaseViewModel
    {
        public string IconPath { get; set; }

        public string NavigationTarget { get; set; }


        public bool IsSelected { get; set; }
    }
}