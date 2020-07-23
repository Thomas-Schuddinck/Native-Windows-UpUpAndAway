using System;
using UpUpAndAwayApp.Models;
using UpUpAndAwayApp.Models.ListItemModels;
using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Webshop : Page
    {

        public WebshopViewModel ViewModel;

        public Webshop()
        {
            this.InitializeComponent();
            this.ViewModel = new WebshopViewModel();
        }

        public void SendToShoppingCart(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = (WebshopItem)button.DataContext;
            ViewModel.AddToShoppingCart(item);
        }

        public void RemoveFromShoppingCart(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = (OrderLine)button.DataContext;
            ViewModel.RemoveItemFromCart(item);
        }

        public void SendCurrentToShoppingCart(object sender, RoutedEventArgs e)
        {
            ViewModel.SendCurrentToShoppingCart();
        }

        public void ChangeSplitviewStatus(object sender, RoutedEventArgs e)
        {
            if (splitview.IsPaneOpen)
            {
                splitview.IsPaneOpen = false;
                CartButton.Visibility = Visibility.Visible;
            }
            else
            {
                splitview.IsPaneOpen = true;
                CartButton.Visibility = Visibility.Collapsed;
            }
        }

        private void SplitviewPaneClosing(SplitView sender, SplitViewPaneClosingEventArgs args)
        {
            CartButton.Visibility = Visibility.Visible;
        }

        public void SetCurrentWebshopItem(WebshopItem webshopItem)
        {
            ViewModel.CurrentWebshopItem = webshopItem;
        }

        public void OpenDetailPanel()
        {
            DetailPane.Visibility = Visibility.Visible;
        }


        public void WebshopItemClicked(object sender, ItemClickEventArgs e)
        {
            var webshopItem = (WebshopItem)e.ClickedItem;
            SetCurrentWebshopItem(webshopItem);
            OpenDetailPanel();
        }
    }

}
