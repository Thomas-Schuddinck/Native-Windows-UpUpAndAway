using Shared.Enums;

namespace Shared.DisplayModels
{
    public abstract class VisualMedia
    {
        #region Properties
        public string ImdbID { get; set; }
        public string Title { get; set; }
        public string Runtime { get; set; }
        public VisualMediaType VisualMediaType { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; } 
        #endregion
    }
}
