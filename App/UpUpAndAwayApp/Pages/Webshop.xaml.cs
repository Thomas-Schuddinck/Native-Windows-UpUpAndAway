﻿using System;
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


        public bool IsSideDrawerOpen { get; set; }
        public bool IsSideDrawerClosed { get; set; }

        public Webshop()
        {
            this.InitializeComponent();
            this.ViewModel = new WebshopViewModel();
        }
        public WebshopViewModel ViewModel;

        public void SendToShoppingCart(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = (WebshopItem)button.DataContext;
            ViewModel.AddToShoppingCart(item);
        }

        public void ChangeSplitviewStatus(object sender, RoutedEventArgs e)
        {
            IsSideDrawerClosed = IsSideDrawerOpen;
            IsSideDrawerOpen = !IsSideDrawerOpen;
            //splitview.IsPaneOpen = !splitview.IsPaneOpen;
            //CartButton.Visibility = splitview.IsPaneOpen ? Visibility.Collapsed : Visibility.Visible;
        }
    }



}
