using Windows.UI.Xaml;
using Shared.DisplayModels;
using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using UpUpAndAwayApp.Utils;

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SerieDetailPage : Page
    {
        public SerieDetailPage()
        {
            this.InitializeComponent();

        }
        public SerieDetailViewModel ViewModel;


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var serie = e.Parameter as Serie;
            this.ViewModel = new SerieDetailViewModel(serie);
        }
        /*
        private void GoBackToOverview()
        {

        }
        */


        private void Play(object sender, RoutedEventArgs e)
        {
            MediaPlayerTool.PlayDefaultMediaFile();
        }
    }
}
