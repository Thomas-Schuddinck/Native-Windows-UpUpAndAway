using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpUpAndAwayApp.Models.Enums;

namespace UpUpAndAwayApp.Models
{
    public abstract class VisualMedia
    {
        public string ImdbID { get; set; }
        public string Title { get; set; }
        public string Runtime { get; set; }
        public VisualMediaType VisualMediaType { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }


    }
}
