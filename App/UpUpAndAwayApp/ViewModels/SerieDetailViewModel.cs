using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpUpAndAwayApp.Models;

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
