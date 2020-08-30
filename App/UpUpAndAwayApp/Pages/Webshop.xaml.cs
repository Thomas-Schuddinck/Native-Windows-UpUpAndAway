using System.Collections.ObjectModel;
using System.Linq;
using Shared.DisplayModels;
using UpUpAndAwayApp.Models.ListItemModels;
using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.UI.Controls;

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

        public void NotifyNewChanges()
        {
            this.Bindings.Update();
        }

        public void SendToShoppingCart(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = (WebshopItem)button.DataContext;
            if(item.Amount != 0)
                ViewModel.AddToShoppingCart(item);
            NotifyNewChanges();
        }
        public void ClearCart(object sender, RoutedEventArgs e)
        {
            ViewModel.ClearCart();
            NotifyNewChanges();
        }

        public void RemoveFromShoppingCart(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = (DisplayOrderLine)button.DataContext;
            ViewModel.RemoveItemFromCart(item);
            NotifyNewChanges();
        }

        public void SendCurrentToShoppingCart(object sender, RoutedEventArgs e)
        {
            ViewModel.SendCurrentToShoppingCart();
            NotifyNewChanges();
        }

        public void SendOrder(object sender, RoutedEventArgs e)
        {
            ViewModel.SendOrder();
            ClearCart(sender, e);
            NotifyNewChanges();
        }

        public void ChangeSplitviewStatus(object sender, RoutedEventArgs e)
        {
            if (splitview.IsPaneOpen)
            {
                splitview.IsPaneOpen = false;
                CartButton.Visibility = Visibility.Visible;
                ClearButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                splitview.IsPaneOpen = true;
                CartButton.Visibility = Visibility.Collapsed;
                ClearButton.Visibility = Visibility.Visible;
            }
        }

        private void SplitviewPaneClosing(SplitView sender, SplitViewPaneClosingEventArgs args)
        {
            CartButton.Visibility = Visibility.Visible;
            ClearButton.Visibility = Visibility.Collapsed;
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

        private void ApplyFilter(object sender, RoutedEventArgs e)
        {

            var min = this.PriceFilter.RangeMin;
            var max = this.PriceFilter.RangeMax;

            this.FilterMinValue.Text = $"Min: {min}";
            this.FilterMaxValue.Text = $"Max: {max}";

            var name = this.NameFilter.Text;

            this.ShopGrid.ItemsSource = new ObservableCollection<WebshopItem>(this.ViewModel.WebshopItems.Where(s => s.Consumable.SellingPrice >= min && s.Consumable.SellingPrice <= max).Where(s => name == "" || s.Consumable.Name.ToUpper().Contains(name.ToUpper())));

        }

        private void PriceFilter_OnValueChanged(object sender, RangeChangedEventArgs e)
        {
            ApplyFilter(null, null);
        }
    }

}
