using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UpUpAndAwayApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClientMusic : Page
    {
        public SongViewModel ViewModel;
        public ClientMusic()
        {
            this.InitializeComponent();
            this.ViewModel = new SongViewModel();
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.PageView.IsPaneOpen = true;
            var song = (Song)e.ClickedItem;
            Navigate_To_SongDetail(song);
        }

        private void Navigate_To_SongDetail(Song song)
        {
            this.ContentFrame.Navigate(typeof(SongDetailPage), song, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            var list = ViewModel.Songs;
            if (Titlefilter.Text != "")
            {
                list = new ObservableCollection<Song>(list.Where(s => s.Title.ToLower().Contains(Titlefilter.Text.ToLower())));
            }
            if (Artistfilter.Text != "")
            {
                list = new ObservableCollection<Song>(list.Where(s => s.Artist.ToLower().Contains(Artistfilter.Text.ToLower())));
            }
            SongList.ItemsSource = list;
        }
    }
}
