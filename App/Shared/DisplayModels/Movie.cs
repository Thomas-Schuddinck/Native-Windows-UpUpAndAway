using Shared.Enums;

namespace Shared.DisplayModels
{
    public class Movie : VisualMedia
    {
        #region Properties
        public string Director { get; set; }
        public string Language { get; set; }
        public string Released { get; set; }
        #endregion

        #region Constructors
        public Movie(string title, string releaseDate, string runtime, string director, string language, string plot, string genre)
        {
            Title = title;
            Released = releaseDate;
            Runtime = runtime;
            VisualMediaType = VisualMediaType.Movie;
            Director = director;
            Language = language;
            Plot = plot;
            Genre = genre;
        } 
        #endregion
    }
}
