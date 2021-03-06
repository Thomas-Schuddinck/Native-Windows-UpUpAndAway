﻿using Shared.DisplayModels.Singleton;
using Shared.Models;
using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClientChat : Page
    {

        ChatViewModel model;
        public ClientChat()
        {
            this.InitializeComponent();
        }

        private async void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            await model.SendMessage(MessageBox.Text);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.model = (ChatViewModel)e.Parameter;
            ChatBox.ItemsSource = model.Chat;
        }
    }
}
