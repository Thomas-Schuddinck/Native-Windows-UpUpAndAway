using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UpUpAndAwayApp.Models;
using UpUpAndAwayApp.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class VisualMediaPage : Page
    {
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
            
            this.ContentFrame.Navigate(typeof(MovieDetailPage), movie, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight } );
        }

        private void Navigate_To_SerieDetail(Serie serie)
        {

            this.ContentFrame.Navigate(typeof(SerieDetailPage), serie, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }
    }
}
