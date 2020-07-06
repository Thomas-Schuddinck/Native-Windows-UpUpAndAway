using API.Models;
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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ClientChat : Page
    {
        public ClientChat()
        {
            this.InitializeComponent();
            Passenger p = new Passenger("Thomas", "Schuddink", 12);
            List<PrivateMessage> items = new List<PrivateMessage>();
            items.Add(new PrivateMessage(p, p, "This is message 1", DateTime.Now));
            items.Add(new PrivateMessage(p, p, "This is message 2", DateTime.Now));
            items.Add(new PrivateMessage(p, p, "This is message 3", DateTime.Now));

            ChatBox.ItemsSource = items;
        }
    }
}
