﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UpUpAndAwayApp.Models;
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
    public sealed partial class ClientFilmsSeries : Page
    {
        public ClientFilmsSeries()
        {
            this.InitializeComponent();
            List<VisualMedia> items = new List<VisualMedia>();
            items.Add(new Movie("Thomas", "10-10-2020", "Thomas","10min", "nl", "Een Thomas die Thomas doet op zijn Thomas best."));

            ChatBox.ItemsSource = items;
        }

        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("flightinfo", typeof(FlightInformation)),
            ("movies/series", typeof(ClientFilmsSeries)),
            ("food/drinks", typeof(FlightInformation)),
            ("weather", typeof(FlightInformation)),
            ("chat", typeof(ClientChat)),
            ("orders", typeof(FlightInformation)),
            ("logout", typeof(MainPage))
        };
        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var navItemTag = args.SelectedItemContainer.Tag.ToString();
            NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
        }

        private void NavView_Navigate(string navItemTag, Windows.UI.Xaml.Media.Animation.NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
            _page = item.Page;
            this.Frame.Navigate(_page, null, transitionInfo);
        }
    }
}
