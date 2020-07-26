using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications; 
using Microsoft.QueryStringDotNET;
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
    public sealed partial class Notification : Page
    {
        public Notification()
        {
            this.InitializeComponent();
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = "Warning!"
                        },

                        new AdaptiveText()
                        {
                            Text = MessageBox.Text
                        }
                    }
                }
            };
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = "Warning!"
                        },

                        new AdaptiveText()
                        {
                            Text = MessageBox.Text
                        }
                    }
                }
            };

            ToastContent toastContent = new ToastContent()
            {
                Visual = visual,

                // Arguments when the user taps body of toast
                Launch = new QueryString()
                {
                    { "action", "viewConversation" }

                }.ToString()
            };
            var toast = new ToastNotification(toastContent.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
