using Shared.DisplayModels;
using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using UpUpAndAwayApp.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
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

            while (true)
            {
                var dialog = new ContentDialog
                {
                    Title = "Set Hangman Word",
                    Content = new TextBox(),
                    PrimaryButtonText = "Set Word"
                };

                // Finally, show the dialog
                var result = await dialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    var input = (TextBox)dialog.Content;
                    var text = input.Text;

                    if (Regex.IsMatch(text, "^([a-zA-Z]+([- ])?)+[a-zA-Z]+$"))
                    {
                        ViewModel.SetWordForGame(item.GameId, input.Text);
                        return;
                    }
                }
            }

        }

        private void HangmanGameClicked(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var hangmanGame = (DisplayGame)button.DataContext;
            Navigate_To_HangmanGame(hangmanGame);
        }

        private void Navigate_To_HangmanGame(DisplayGame game)
        {
            this.Frame.Navigate(typeof(HangmanGamePage), game, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }
    }
}
