using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpUpAndAwayApp.Models.Enums;

namespace UpUpAndAwayApp.Models
{
    public class Movie : VisualMedia
    {
        public string Director { get; set; }
        public string Language { get; set; }
        public string ReleaseDate { get; set; }

        public Movie(string title, string releaseDate, string runtime, string director, string language, string plot)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Runtime = runtime;
            VisualMediaType = VisualMediaType.Movie;
            Director = director;
            Language = language;
            Plot = plot;
        }
    }
}
