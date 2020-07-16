﻿using Windows.UI.Xaml.Controls;
using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml.Navigation;
using UpUpAndAwayApp.Models;

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MovieDetailPage : Page
    {
        public MovieDetailPage()
        {
            this.InitializeComponent();
            
        }
        public MovieDetailViewModel ViewModel;


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var movie = e.Parameter as Movie;
            this.ViewModel = new MovieDetailViewModel(movie);
        }

    }
}