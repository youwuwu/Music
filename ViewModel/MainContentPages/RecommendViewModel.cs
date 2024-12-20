﻿using System.Collections.ObjectModel;
using Music.Model;
using Unity;

namespace Music.ViewModel.MainContentPages
{
    class RecommendViewModel : ContentViewModelBase
    {
        [InjectionConstructor]
        public RecommendViewModel()
        {
            var albumsGroup = FakeDataCreator.CreateAlbumGroup(3);
            albumsGroup.Title = "Hi 吴希彤 今日为你推荐";
            AlbumsGroupList.Add(albumsGroup);

            albumsGroup       = FakeDataCreator.CreateAlbumGroup(12);
            albumsGroup.Title = "你的宝藏库";
            AlbumsGroupList.Add(albumsGroup);


            albumsGroup       = FakeDataCreator.CreateAlbumGroup(6);
            albumsGroup.Title = "大家都在听";
            AlbumsGroupList.Add(albumsGroup);


            albumsGroup       = FakeDataCreator.CreateAlbumGroup(12);
            albumsGroup.Title = "符合你最近的音乐";
            AlbumsGroupList.Add(albumsGroup);


            albumsGroup       = FakeDataCreator.CreateAlbumGroup(6);
            albumsGroup.Title = "你喜爱的歌手，这里都有";
            AlbumsGroupList.Add(albumsGroup);


            albumsGroup       = FakeDataCreator.CreateAlbumGroup(6);
            albumsGroup.Title = "最热门的电台节目，一键获得";
            AlbumsGroupList.Add(albumsGroup);


            albumsGroup       = FakeDataCreator.CreateAlbumGroup(6);
            albumsGroup.Title = "为你推荐话语流行歌";
            AlbumsGroupList.Add(albumsGroup);
        }

        public ObservableCollection<AlbumsGroup> AlbumsGroupList { get; } = new();

    }
}