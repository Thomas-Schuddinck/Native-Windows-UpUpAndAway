using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NavigationPagePersonel : Page
    {
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("orders", typeof(PersonelOrderPage)),
            ("promotions", typeof(VisualMediaPage)),
            ("messaging", typeof(Webshop)),
            ("logout", typeof(MainPage))
        };
        public NavigationPagePersonel()
        {
            this.InitializeComponent();
            var item = _pages.FirstOrDefault(p => p.Tag.Equals("orders"));
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
            if (item.Tag.Equals("logout"))
            {
                this.Frame.Navigate(_page, null, transitionInfo);
            }
            else
            {
                this.ContentFrame.Navigate(_page, this.ContentFrame, transitionInfo);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
