using Shared.DisplayModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpUpAndAwayApp.ViewModels
{
    public class SongDetailViewModel
    {
        public Song CurrentSong { get; private set; }

        public SongDetailViewModel(Song song)
        {
            CurrentSong = song;
        }
    }
}
