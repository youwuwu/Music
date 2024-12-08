using System.Collections.ObjectModel;
using MvvmHelpers;

namespace Music.Model
{
    class AlbumsGroup : BaseViewModel
    {

        public ObservableCollection<Album> Albums { get; } = new();
    }
}