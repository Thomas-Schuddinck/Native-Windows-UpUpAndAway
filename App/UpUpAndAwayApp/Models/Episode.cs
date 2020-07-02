using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpUpAndAwayApp.Models.Enums;

namespace UpUpAndAwayApp.Models
{
    public class Episode : VisualMedia
    {
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }

        public Episode(string title, string runtime, string plot, int seasonNumber, int episodeNumber)
        {
            Title = title;
            Runtime = runtime;
            VisualMediaType = VisualMediaType.Episode;
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
            Plot = plot;
        }

    }
}
