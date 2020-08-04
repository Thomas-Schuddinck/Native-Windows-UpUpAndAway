using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UpUpAndAwayApp.ViewModels;
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
    public sealed partial class SeatManagement : Page
    {
        public SeatManagementViewModel VM { get; set; }
        public SeatManagement()
        {
            VM = new SeatManagementViewModel();
            this.InitializeComponent();
        }



        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            VM.SaveChanges();
        }

        private void ChangeFirst(object sender, SelectionChangedEventArgs e)
        {
            var item = e.AddedItems[0];
            VM.SelectedSeat = (Shared.Models.Seat)item;
            this.Bindings.Update();
        }

        private void ChangeSecond(object sender, SelectionChangedEventArgs e)
        {
            var item = e.AddedItems[0];
            VM.SwapTo = (Shared.Models.Seat)item;
            this.Bindings.Update();
        }
    }
}
