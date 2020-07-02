using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpUpAndAwayApp.Models.Enums;

namespace UpUpAndAwayApp.Models
{
    public class Serie : VisualMedia
    {
        public string Director { get; set; }
        public string Language { get; set; }
        public int NumberOfSeasons { get; set; }
        public string ReleaseDate { get; set; }

        public Serie(string title, string runtime, string director, string language, string plot, int numberOfSeasons, string releaseDate)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Runtime = runtime;
            VisualMediaType = VisualMediaType.Serie;
            Director = director;
            Language = language;
            Plot = plot;
            NumberOfSeasons = numberOfSeasons;
        }
    }
}
