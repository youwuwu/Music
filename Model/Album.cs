using System;
using System.Collections.ObjectModel;
using MoreLinq;
using MvvmHelpers;

namespace Music.Model
{
    public class Album : BaseViewModel
    {
        public string CoverImageUrl { get; set; }

        public ObservableCollection<string> Tags { get; set; } = new();

      
        public string PlayCountText { get; set; }

  
        public string CollectionCountText { get; set; }

  
        public string Language { get; set; }

  
        public DateTime PublishDate { get; set; }


        public string PublisherCompany { get; set; }


        private readonly ObservableCollection<Song> _songs = new();

    
        public ObservableCollection<Song> Songs
        {
            get => _songs;
            init
            {
                _songs = value;
                _songs.ForEach(v => v.ParentAlbum = this);
            }
        }

        public string Description { get; set; }
    }
}