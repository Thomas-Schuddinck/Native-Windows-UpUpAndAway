using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class NavigationPagePersonel : Page
    {
        PersonnelChatViewModel vm;
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("seats", typeof(SeatManagement)),
            ("reductions", typeof(ChangeReduction)),
            ("logout", typeof(MainPage))
        };
        public NavigationPagePersonel()
        {
            this.InitializeComponent();
            var item = _pages.FirstOrDefault(p => p.Tag.Equals("seats"));
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
                //vm.Disconnect();
                this.Frame.Navigate(_page, null, transitionInfo);
            }
            //else if (item.Tag.Equals("chat"))
            //{

            //    this.vm = new PersonnelChatViewModel();
            //    try
            //    {
            //        var task = Task.Run(async () => { await vm.Connect(); });
            //        task.Wait();
            //        this.ContentFrame.Navigate(_page, vm, transitionInfo);
            //    }
            //    catch (Exception er)
            //    {
            //        var p = new ContentDialog();
            //        p.Title = "Connection error";
            //        p.CloseButtonText = "close";
            //        p.ShowAsync();
            //    }
            //}
            else
            {
                this.ContentFrame.Navigate(_page, this.ContentFrame, transitionInfo);
            }
        }
    }
}
