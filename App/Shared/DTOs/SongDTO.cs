using Shared.Models;

namespace Shared.DTOs
{
    public class SongDTO
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
        public SongDTO() { }
        public SongDTO(Song s)
        {
            Title = s.Title;
            Artist = s.Artist;
            Released = s.Released;
            Genre = s.Genre;
            MP3FilePath = s.MP3FilePath;
            SongBanner = s.SongBanner;
        }
        #endregion
    }
}
