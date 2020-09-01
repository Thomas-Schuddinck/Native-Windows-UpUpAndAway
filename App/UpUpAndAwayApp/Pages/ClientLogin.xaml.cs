using System;
using System.Threading.Tasks;
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
            try
            {
                Task task = ViewModel.LoginPassenger(login);
                task.Wait();
                this.Frame.Navigate(typeof(NavPagePassenger));
            }
            catch (Exception er)
            {
                var p = new ContentDialog();
                if(er is AggregateException && er.InnerException is ArgumentException)
                    p.Title = "Incorrect seatnumber";
                else
                    p.Title = "Connection error";
                p.CloseButtonText = "close";
                p.ShowAsync();
            }
        }
    }
}
