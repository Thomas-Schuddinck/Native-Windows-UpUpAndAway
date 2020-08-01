using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; 
using Microsoft.QueryStringDotNET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UpUpAndAwayApp.ViewModels;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Notification : Page
    {
        PersonnelChatViewModel model;
        public Notification()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.model = (PersonnelChatViewModel)e.Parameter;
            var task = Task.Run(async () => {
                await model.GetPassengers();
            });
            task.Wait();
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            if(Passengerlist.Visibility == Visibility.Collapsed)
            {
                model.SendWarning(MessageBox.Text);
            }
            else
            {
                model.SendWarningToPassenger(MessageBox.Text, Passengerlist.SelectedItem.ToString());
            }
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            var task = Task.Run(async () => {
                await model.GetPassengers();
            });
            task.Wait();
            this.Bindings.Update();
            Passengerlist.Visibility = Sendtype.IsOn ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
