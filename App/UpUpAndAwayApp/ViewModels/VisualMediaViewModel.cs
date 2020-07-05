using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpUpAndAwayApp.Models;
namespace UpUpAndAwayApp.ViewModels
{
    public class VisualMediaViewModel
    {
        public IReadOnlyList<Movie> Movies { get; private set; }
    }
}
