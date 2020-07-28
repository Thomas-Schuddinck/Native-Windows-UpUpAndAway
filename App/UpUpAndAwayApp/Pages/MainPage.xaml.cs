using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UpUpAndAwayApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.ViewModel = new FlightInfoViewModel();
        }
        public FlightInfoViewModel ViewModel;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate( typeof(LoginClient));
        }
    }
}
