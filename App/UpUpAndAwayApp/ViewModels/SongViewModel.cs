using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Shared.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace UpUpAndAwayApp.ViewModels
{
    public class SongViewModel
    {
        public ObservableCollection<Song> Songs { get; private set; }

        public SongViewModel()
        {
            Songs = new ObservableCollection<Song>();
            GetSongsFromAPI();
        }

        private async void GetSongsFromAPI()
        {
            HttpClient client = new HttpClient();
            var jsonResponse = await client.GetStringAsync(new Uri(GenerateSongRequestString()));
            var song = JsonConvert.DeserializeObject<List<Song>>(jsonResponse);
            song.ForEach(s => {
                Songs.Add(s);
                }); ;
        }

        private string GenerateSongRequestString()
        {
            return String.Format("http://localhost:5000/api/Song");
        }
    }
}
