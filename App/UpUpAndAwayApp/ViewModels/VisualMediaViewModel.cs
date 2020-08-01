using Newtonsoft.Json;
using Shared.DisplayModels;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using UpUpAndAwayApp.Data;

namespace UpUpAndAwayApp.ViewModels
{
    public class VisualMediaViewModel
    {
        
        public ObservableCollection<Movie> Movies { get; private set; }
        public ObservableCollection<Movie> HighlightedMovies { get; private set; }
        public ObservableCollection<Serie> Series { get; private set; }
        public ObservableCollection<Serie> HighlightedSeries { get; private set; }

        public VisualMediaViewModel()
        {
            Movies = new ObservableCollection<Movie>();
            Series = new ObservableCollection<Serie>();
            GetMoviesFromAPI();
            GetSeriesFromAPI();
        }
        
        private async void GetMoviesFromAPI()
        {
            HttpClient client = new HttpClient();
            foreach(string id in VisualMediaData.movieTitels)
            {
                var jsonResponse = await client.GetStringAsync(new Uri(GenerateMovieRequestString(id)));
                var movie = JsonConvert.DeserializeObject<Movie>(jsonResponse);
                Movies.Add(movie);
            }
        }

        private async void GetSeriesFromAPI()
        {
            HttpClient client = new HttpClient();
            foreach (string title in VisualMediaData.serieTitels)
            {
                var jsonResponse = await client.GetStringAsync(new Uri(GenerateSerieRequestString(title)));
                var serie = JsonConvert.DeserializeObject<Serie>(jsonResponse);
                Series.Add(serie);
            }
        }

        private string GenerateMovieRequestString(string movieTitle)
        {
            return String.Format("{0}&t={1}&type=movie&plot=full", ApiData.baseUriOMDB, movieTitle);
        }

        private string GenerateSerieRequestString(string serieTitle)
        {
            return String.Format("{0}&t={1}&type=series&plot=full", ApiData.baseUriOMDB, serieTitle);
        }
    }
}
