using Shared.Models.Singleton;
using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FlightInformation : Page
    {
        private FlightInfoSingleton flightInfoSingleton;
        private FlightInfoViewModel ViewModel { get; set; }

        public FlightInformation()
        {
            this.InitializeComponent();
            this.flightInfoSingleton = FlightInfoSingleton.GetInstance();
            ViewModel = new FlightInfoViewModel();
        }
    }
}
