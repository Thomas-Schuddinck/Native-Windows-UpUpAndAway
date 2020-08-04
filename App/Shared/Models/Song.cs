using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class Song
    {
        #region Properties
        public int SongId { get; set; }
        public string Artist { get; set; }
        public string Released { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string MP3FilePath { get; set; }
        public string SongBanner { get; set; }
        #endregion

        #region Constructors
        public Song() { }

        public Song(string title, string artist, string releaseDate, string genre, string mp3, string songbanner)
        {
            Title = title;
            Artist = artist;
            Released = releaseDate;
            Genre = genre;
            MP3FilePath = mp3;
            SongBanner = songbanner;
        }

        public Song(SongDTO SongDTO)
        {
            SongId = SongDTO.SongId;
            Title = SongDTO.Title;
            Artist = SongDTO.Artist;
            Released = SongDTO.Released;
            Genre = SongDTO.Genre;
            MP3FilePath = SongDTO.MP3FilePath;
            SongBanner = SongDTO.SongBanner;
        }
        #endregion
    }
}
