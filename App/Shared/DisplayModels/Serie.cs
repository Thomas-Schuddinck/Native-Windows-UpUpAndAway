using Shared.Enums;

namespace Shared.DisplayModels
{
    public class Serie : VisualMedia
    {
        #region Properties
        public string Director { get; set; }
        public string Language { get; set; }
        public int TotalSeasons { get; set; }
        public string Released { get; set; }
        #endregion

        #region ReadOnly-Properties
        public string NumSeasons => TotalSeasons + " seizoenen"; 
        #endregion

        #region Constructors
        public Serie(string title, string runtime, string director, string language, string plot, int totalSeasons, string releaseDate, string genre)
        {
            Title = title;
            Released = releaseDate;
            Runtime = runtime;
            VisualMediaType = VisualMediaType.Serie;
            Director = director;
            Language = language;
            Plot = plot;
            TotalSeasons = totalSeasons;
            Genre = genre;
        } 
        #endregion
    }
}
