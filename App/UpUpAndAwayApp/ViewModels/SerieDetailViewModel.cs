using Shared.DisplayModels;

namespace UpUpAndAwayApp.ViewModels
{
    public class SerieDetailViewModel
    {
        public Serie CurrentSerie { get; private set; }

        public SerieDetailViewModel(Serie serie)
        {
            CurrentSerie = serie;
        }
    }
}
