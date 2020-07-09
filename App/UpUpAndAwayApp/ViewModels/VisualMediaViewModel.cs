using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UpUpAndAwayApp.Data;
using UpUpAndAwayApp.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

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
        
        public async void GetMoviesFromAPI()
        {
            HttpClient client = new HttpClient();
            foreach(string id in VisualMediaData.movieIDs)
            {
                var jsonResponse = await client.GetStringAsync(new Uri(GenerateMovieRequestString(id)));
                var movie = JsonConvert.DeserializeObject<Movie>(jsonResponse);
                Movies.Add(movie);
            }
        }

        
        public async void GetSeriesFromAPI()
        {
            HttpClient client = new HttpClient();
            foreach (string id in VisualMediaData.serieIDs)
            {
                var jsonResponse = await client.GetStringAsync(new Uri(GenerateMovieRequestString(id)));
                var serie = JsonConvert.DeserializeObject<Serie>(jsonResponse);
                Series.Add(serie);
            }
        }

        public string GenerateMovieRequestString(string movieId)
        {
            return String.Format("{0}&i={1}&type=movie", ApiData.baseUriOMDB, movieId);
        }

        public string GenerateSerieRequestString(string serieId)
        {
            return String.Format("{0}&i={1}&type=series", ApiData.baseUriOMDB, serieId);
        }
    }
}
