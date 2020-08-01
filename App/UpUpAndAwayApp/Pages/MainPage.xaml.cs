using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        private void PassengerLogin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginClient));
        }

        private void StaffLogin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NavigationPagePersonel));
        }

        private void Personeel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Notification));
        }
    }
}
