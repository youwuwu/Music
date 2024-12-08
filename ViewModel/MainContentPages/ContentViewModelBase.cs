using MvvmHelpers;
using Music.ViewModel.Menu;
using Prism.Regions;

namespace Music.ViewModel.MainContentPages
{
    internal class ContentViewModelBase : BaseViewModel, INavigationAware
    {
       
        protected IRegionNavigationJournal Journal;

        protected MenuItemViewModel MenuItemViewModel;

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Journal = navigationContext.NavigationService.Journal;

            if (navigationContext.Parameters["MenuItemViewModel"] is MenuItemViewModel menuItemViewModel)
            {
                MenuItemViewModel            = menuItemViewModel;
                MenuItemViewModel.IsSelected = true;
            }

        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            if (MenuItemViewModel is not null)
            {
                MenuItemViewModel.IsSelected = false;
            }
        }
    }
}