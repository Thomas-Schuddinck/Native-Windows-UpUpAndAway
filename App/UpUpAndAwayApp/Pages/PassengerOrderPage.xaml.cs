using Shared.DisplayModels;
using UpUpAndAwayApp.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using UpUpAndAwayApp.Utils;
using System.Windows.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PassengerOrderPage : Page
    {
        public PassengerOrderPage()
        {
            this.InitializeComponent();
            this.ViewModel = new OrderViewModel();
        }
        public OrderViewModel ViewModel;
        public Frame ContentFrame { get; private set; }

        public void OrderListItemClicked(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = (DisplayOrder)button.DataContext;
            ViewModel.CurrentOpenOrder = item;
            OpenDetailPanel();
        }

        public void OpenDetailPanel()
        {
            OrderDetails.Visibility = Visibility.Visible;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            OrderDetails.Visibility = Visibility.Collapsed;
        }

        public void OrderListItemClosedClicked(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = (DisplayOrder)button.DataContext;
            ViewModel.CurrentClosedOrder = item;
            OpenDetailPanelClosed();
        }

        public void OpenDetailPanelClosed()
        {
            OrderDetailsClosed.Visibility = Visibility.Visible;
        }

        private void CloseButtonClosed_Click(object sender, RoutedEventArgs e)
        {
            OrderDetailsClosed.Visibility = Visibility.Collapsed;
        }
    }
}
