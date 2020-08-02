using Shared.DisplayModels;
using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PassengerOrderPage : Page
    {
        public PassengerOrderPage()
        {
            this.InitializeComponent();
            this.ViewModel = new PassengerOrderViewModel();
        }
        public PassengerOrderViewModel ViewModel;
        public Frame ContentFrame { get; private set; }

        private void OrderListItemClicked(object sender, ItemClickEventArgs e)
        {
            var clickedMovie = (Movie)e.ClickedItem;
            Navigate_To_OrderDetail(clickedMovie);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ContentFrame = e.Parameter as Frame;
        }

        private void Navigate_To_OrderDetail(Movie movie)
        {
            
            this.ContentFrame.Navigate(typeof(MovieDetailPage), movie, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight } );
        }
    }
}
