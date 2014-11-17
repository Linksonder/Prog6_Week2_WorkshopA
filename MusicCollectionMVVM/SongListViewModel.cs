﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicCollectionMVVM
{
    public class SongListviewModel
    {
        ISongRepository songRepository;

        public SongViewModel Song { get; set; }

        public ObservableCollection<SongViewModel> Songs { get; set; }

        public ICommand AddSong { get; set; }

        public SongListviewModel()
        {
            songRepository = new DummySongRepository();
            var songList = songRepository.ToList().Select(s => new SongViewModel(s));

            Song = new SongViewModel();
            Songs = new ObservableCollection<SongViewModel>(songList);
            AddSong = new RelayCommand(AddNewSong);
        }


        private void AddNewSong(object parameter)
        {
            Songs.Add(Song);
        }
    }
}
