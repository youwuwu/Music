using MvvmHelpers;

namespace Music.ViewModel.Menu
{
    public class MenuGroupViewModel : BaseViewModel
    {
        public ObservableRangeCollection<MenuItemViewModel> MenuItems { get; set; }
    }
}