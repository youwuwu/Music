using System.Collections.ObjectModel;
using MvvmHelpers;
using Music.Model;

namespace Music.ViewModel.SongsViews
{
    public class SongsListViewModel : BaseViewModel
    {
        public ObservableCollection<Song> Songs { get; set; } = new();
    }
}