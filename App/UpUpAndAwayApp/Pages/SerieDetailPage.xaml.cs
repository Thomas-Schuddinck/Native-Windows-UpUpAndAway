﻿using Windows.UI.Xaml;
using Shared.DisplayModels;
using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using UpUpAndAwayApp.Utils;

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SerieDetailPage : Page
    {
        public SerieDetailPage()
        {
            this.InitializeComponent();

        }
        public SerieDetailViewModel ViewModel;


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var serie = e.Parameter as Serie;
            this.ViewModel = new SerieDetailViewModel(serie);
            this.SeasonsBox.SelectedIndex = 0;
            this.EpisodeBox.SelectedIndex = 0;
        }
        /*
        private void GoBackToOverview()
        {

        }
        */


        private void Play(object sender, RoutedEventArgs e)
        {
            MediaPlayerTool.PlayDefaultMediaFile();
        }

        private void SelectSeason(object sender, SelectionChangedEventArgs e)
        {
            var season = this.SeasonsBox.SelectedIndex + 1;
            ViewModel.SelectedSeason = season;
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
