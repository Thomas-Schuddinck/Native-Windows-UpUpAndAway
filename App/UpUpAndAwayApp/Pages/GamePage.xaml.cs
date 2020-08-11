using Shared.DisplayModels;
using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
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
    public sealed partial class GamePage : Page
    {
        public GamePage()
        {
            this.InitializeComponent();

            this.ViewModel = new GameViewModel();
        }
        public GameViewModel ViewModel;

        private void CreateNewGame(object sender, RoutedEventArgs e)
        {
            var t = (GameType)GameType.SelectedItem;
            var s = (Passenger)PartyMember.SelectedItem;
            ViewModel.CreateGame((GameType)GameType.SelectedItem, (Passenger)PartyMember.SelectedItem);
        }


        public void SetWordHangmanGame(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = (DisplayGame)button.DataContext;
            GetWordForGame(item);
            
        }

        private async void GetWordForGame(DisplayGame item)
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Set Hangman Word",
                Content = new TextBox(),
                PrimaryButtonText = "Set Word"
            };

            // Finally, show the dialog
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                TextBox input = (TextBox)dialog.Content;
                ViewModel.SetWordForGame(item.GameId, input.Text); 
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
