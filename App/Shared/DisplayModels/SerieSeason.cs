using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DisplayModels
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    using System.Globalization;


    public class SerieSeason
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Season")]
        public long Season { get; set; }

        [JsonProperty("totalSeasons")]
        public long TotalSeasons { get; set; }

        [JsonProperty("Episodes")]
        public Episode[] Episodes { get; set; }

        [JsonProperty("Response")]
        public string Response { get; set; }

    }

    public class Episode
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Released")]
        public DateTimeOffset Released { get; set; }

        [JsonProperty("Episode")]
        public long EpisodeNumber { get; set; }

        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbId { get; set; }

        public string Display => $"Ep. {EpisodeNumber}: {Title}";
    }
}

