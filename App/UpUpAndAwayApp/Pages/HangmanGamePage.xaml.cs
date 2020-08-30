using Shared.DisplayModels;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HangmanGamePage : Page
    {
        public HangmanGameViewModel ViewModel;

        public HangmanGamePage()
        {            
            this.InitializeComponent();
            LetterGuesser.SelectionChanged += LetterGuesser_SelectedIndexChanged;
            WordGuesser.SelectionChanged += WordGuesser_InputChanged;
            CheckLetterSelection();
            CheckWordSelection();
        }

        private void LetterGuesser_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckLetterSelection();
        }

        private void WordGuesser_InputChanged(object sender, RoutedEventArgs e)
        {
            CheckWordSelection();
        }

        void CheckLetterSelection()
        {
            if (LetterGuesser.SelectedItem != null)
            {
                LetterGuesserButton.IsEnabled = true;
            }
            else
                LetterGuesserButton.IsEnabled = false;
        }

        void CheckWordSelection()
        {
            if (WordGuesser.Text.Trim() != "")
            {
                WordGuesserButton.IsEnabled = true;
            }
            else
                WordGuesserButton.IsEnabled = false;
        }

        private void ResetInput()
        {
            WordGuesser.Text = "";
            LetterGuesser.SelectedItem = null;
        }

        private void GuessLetter(object sender, RoutedEventArgs e)
        {
            char c = (char)LetterGuesser.SelectedValue;
            LetterGuesser.IsDropDownOpen = false;
            ViewModel.AddCharGuess(c);
            ResetInput();
        }

        public async void CreateGameFinishedDialog(string msg)
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Game Finished",
                Content = msg,
                PrimaryButtonText = "Overview"
            };

            // Finally, show the dialog
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                NavigateBack();
            }

        }

        private void GuessWord(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(this.WordGuesser.Text, "^([a-zA-Z]+([- ])?)+[a-zA-Z]+$"))
            {
                this.WordGuesser.BorderBrush=new SolidColorBrush(Colors.Red);
                ResetInput();
                return;
            }
            ViewModel.AddWordGuess(WordGuesser.Text);
            ResetInput();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var game = e.Parameter as DisplayGame;
            this.ViewModel = new HangmanGameViewModel(game, this);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.SaveGame();
            base.OnNavigatedFrom(e);
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigateBack();
        }

        private void NavigateBack()
        {
            this.Frame.GoBack();
        }

        private void ResetBorderColour(object sender, RoutedEventArgs e)
        {
            this.WordGuesser.ClearValue(BorderBrushProperty);
        }
    }
}
