using Shared.DisplayModels;

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
