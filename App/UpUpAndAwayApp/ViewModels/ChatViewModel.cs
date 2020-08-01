using Microsoft.AspNetCore.SignalR.Client;
using Shared.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.AspNetCore.Http;
using Windows.UI.Notifications;
using Microsoft.AspNetCore.Http.Connections.Client;
using Shared.DisplayModels.Singleton;

namespace UpUpAndAwayApp.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        public HubConnection hubConnection;
        public ObservableCollection<PrivateMessage> Chat;

        public event PropertyChangedEventHandler PropertyChanged;

        public ChatViewModel()
        {
            Chat = new ObservableCollection<PrivateMessage>();
            var id = LoginSingleton.passenger.PassengerId;
            hubConnection = new HubConnectionBuilder().WithUrl("http://localhost:5000/chatHub?name=" + id).WithAutomaticReconnect().Build();

            hubConnection.On<string, string>("ReceiveMessage", (name, message) =>
            {
                var fullname = name.Split(' ', 2);
                Passenger p = new Passenger(fullname[0],fullname[1]);
                Chat.Add(new PrivateMessage(p, message));
                //Chat.Add(new PrivateMessage(LoginSingleton.passenger, message));
            });
            hubConnection.On< string>("ReceiveWarning", ( message) =>
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
                            Text = message
                        }
                    }
                    }
                };

                ToastContent toastContent = new ToastContent()
                {
                    Visual = visual
                };
                var toast = new ToastNotification(toastContent.GetXml());
                ToastNotificationManager.CreateToastNotifier().Show(toast);
            });
        }

        public async Task Connect()
        {
            await hubConnection.StartAsync();
            await hubConnection.InvokeAsync("JoinRoom", LoginSingleton.passengerGroupId.ToString());
        }

        public async Task SendMessage(string message)
        {
            await hubConnection.InvokeAsync("SendMessage", LoginSingleton.passengerGroupId.ToString(), LoginSingleton.passenger.FullName, message);
        }

        public async Task Disconnect()
        {
            await hubConnection.StopAsync();
        }
    }
}
