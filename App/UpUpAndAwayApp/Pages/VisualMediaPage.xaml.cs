using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Shared.DisplayModels;
using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VisualMediaPage : Page
    {

        private string currentType;

        public VisualMediaPage()
        {
            this.InitializeComponent();
            this.ViewModel = new VisualMediaViewModel();
        }
        public VisualMediaViewModel ViewModel;
        public Frame ContentFrame { get; private set; }

        private void MovieListItemClicked(object sender, ItemClickEventArgs e)
        {
            var clickedMovie = (Movie)e.ClickedItem;
            Navigate_To_MovieDetail(clickedMovie);
        }

        private void SerieListItemClicked(object sender, ItemClickEventArgs e)
        {
            var clickedSerie = (Serie)e.ClickedItem;
            Navigate_To_SerieDetail(clickedSerie);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ContentFrame = e.Parameter as Frame;
        }

        private void Navigate_To_MovieDetail(Movie movie)
        {

            this.ContentFrame.Navigate(typeof(MovieDetailPage), movie, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        private void Navigate_To_SerieDetail(Serie serie)
        {

            this.ContentFrame.Navigate(typeof(SerieDetailPage), serie, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        private void ApplyFilter(object sender, RoutedEventArgs e)
        {
            var genreraw = this.GenreFilterBox.SelectedValue ?? "All";
            string genre = genreraw.ToString();

            var title = this.SearchBar.Text;


            switch (currentType.ToUpper())//Oneliner?
            {
                case "MOVIES":
                    this.MoviesView.ItemsSource = new ObservableCollection<Movie>(ViewModel.Movies.Where(s => genre == "All" || s.Genre.ToUpper().Contains(genre.ToUpper()))).Where(s => title == "" || s.Title.ToUpper().Contains(title.ToUpper()));
                    break;
                case "SERIES":
                    this.SeriesView.ItemsSource = new ObservableCollection<Serie>(ViewModel.Series.Where(s => genre == "All" || s.Genre.ToUpper().Contains(genre.ToUpper()))).Where(s => title == "" || s.Title.ToUpper().Contains(title.ToUpper()));
                    break;
            }
        }


        private void ChangePivotView(object sender, SelectionChangedEventArgs e)
        {
            switch (Pivot.SelectedIndex)
            {
                case 0:
                    currentType = "Movies";
                    break;
                case 1:
                    currentType = "Series";
                    break;
                default:
                    currentType = "wot";
                    break;
            }
        }

    }
}
