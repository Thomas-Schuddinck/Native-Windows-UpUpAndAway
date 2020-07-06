using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public partial class NavPage : Page
    {
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("flightinfo", typeof(FlightInformation)),
            ("movies/series", typeof(VisualMediaPage)),
            ("food/drinks", typeof(FlightInformation)),
            ("weather", typeof(FlightInformation)),
            ("chat", typeof(ClientChat)),
            ("orders", typeof(FlightInformation)),
            ("logout", typeof(MainPage))
        };
        public NavPage()
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

        private void NavView_Navigate( string navItemTag, Windows.UI.Xaml.Media.Animation.NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
            _page = item.Page;
            this.ContentFrame.Navigate(_page, null, transitionInfo);
        }
    }
}
