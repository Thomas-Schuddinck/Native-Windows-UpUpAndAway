using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpUpAndAwayApp.Models;

namespace UpUpAndAwayApp.ViewModels
{
    public class MovieDetailViewModel
    {
        public Movie CurrentMovie { get; private set; }

        public MovieDetailViewModel(Movie movie)
        {
            CurrentMovie = movie;
        }
        

    }
}
