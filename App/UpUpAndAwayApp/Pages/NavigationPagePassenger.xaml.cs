﻿using System;
using System.Collections.Generic;
using System.Linq;
using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpUpAndAwayApp.Pages
{
    public partial class NavPagePassenger : Page
    {
        ChatViewModel vm;
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("flightinfo", typeof(FlightInformation)),
            ("movies/series", typeof(VisualMediaPage)),
            ("food/drinks", typeof(Webshop)),
            ("music", typeof(ClientMusic)),
            ("chat", typeof(ClientChat)),
            ("orders", typeof(PassengerOrderPage)),
            ("games", typeof(GamePage)),
            ("logout", typeof(MainPage))
        };
        public NavPagePassenger()
        {
            this.InitializeComponent();
            var item = _pages.FirstOrDefault(p => p.Tag.Equals("flightinfo"));
            Type _page = item.Page;
            this.ContentFrame.Navigate(_page, null);
        }
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
            if (item.Tag.Equals("logout")) {
                vm.Disconnect();
                this.Frame.Navigate(_page, null, transitionInfo);
            }
            else if(item.Tag.Equals("chat")) {
                this.ContentFrame.Navigate(_page, vm, transitionInfo);
            }
            else {
                this.ContentFrame.Navigate(_page, this.ContentFrame, transitionInfo);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.vm = new ChatViewModel();
            vm.Connect();
        }
    }
}
