using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Shared.DisplayModels;
using UpUpAndAwayApp.Data;

namespace UpUpAndAwayApp.ViewModels
{
    public class SerieDetailViewModel
    {


        public Serie CurrentSerie { get; private set; }

        private int _selectedSeason = 1;

        public int SelectedSeason
        {
            get => _selectedSeason;
            set
            {
                _selectedSeason = value;
                GetEpisodesFromAPI();
            }
        }

        public int SelectedEpisode { get; set; } = 1;

        public ObservableCollection<string> Episodes { get; set; }


        public SerieDetailViewModel(Serie serie)
        {
            CurrentSerie = serie;
            Episodes = new ObservableCollection<string>();
            GetEpisodesFromAPI();
        }

        private async void GetEpisodesFromAPI()
        {
            HttpClient client = new HttpClient();
            foreach (string title in VisualMediaData.serieTitels)
            {
                var jsonResponse = await client.GetStringAsync(new Uri(GenerateSerieRequestString()));
                var season = JsonConvert.DeserializeObject<SerieSeason>(jsonResponse).Episodes;
                Episodes.Clear();
                season.OrderBy(s => s.EpisodeNumber).ToList().ForEach(s => Episodes.Add(s.Display));
            }
        }

        private string GenerateSerieRequestString()
        {
            return String.Format("{0}&t={1}&Season={2}", ApiData.baseUriOMDB, CurrentSerie.Title, SelectedSeason);
        }

    }
}
//http://www.omdbapi.com/?apikey=8f0aafb7&t=%22Game%20of%20Thrones%22&Season=2