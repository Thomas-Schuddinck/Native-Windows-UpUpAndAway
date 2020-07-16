using API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClientChat : Page
    {

        List<PrivateMessage> items;
        ChatViewModel observable;
        public ClientChat()
        {
            observable = new ChatViewModel();
            this.InitializeComponent();
            ChatBox.ItemsSource = observable.Chat;
        }

        private async void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            Passenger p = new Passenger("Stef", "Doorbreaker", 13);
            await observable.Connect();
            await observable.SendMessage(p, MessageBox.Text);
            await observable.Disconnect();
        }
    }
}
