using MvvmHelpers;

namespace Music.Model
{
    public class Song : BaseViewModel
    {
     
        public string AudioFile { get; set; }

       
        public bool IsLiked { get; set; }

      
        public string PlayerName { get; set; }

       
        public Album ParentAlbum { get; set; }
    }
}