using UpUpAndAwayApp.Pages;
using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpUpAndAwayApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginClient : Page
    {

        public PassengerViewModel ViewModel;
        public LoginClient()
        {
            this.InitializeComponent();
            this.ViewModel = new PassengerViewModel();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            ViewModel.LoginPassenger(login);
            this.Frame.Navigate(typeof(NavPage));
        }
    }
}
