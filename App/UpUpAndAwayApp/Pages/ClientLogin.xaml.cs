using API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UpUpAndAwayApp.Models.Singleton;
using UpUpAndAwayApp.Pages;
using UpUpAndAwayApp.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
                ViewModel.LoginPassenger(login).RunSynchronously();
                this.Frame.Navigate(typeof(NavPagePassenger));
            }
            catch(Exception er)
            {
                var p = new ContentDialog();
                p.Title = "Connection error";
                p.CloseButtonText = "close";
                p.ShowAsync();
            }
        }
    }
}
