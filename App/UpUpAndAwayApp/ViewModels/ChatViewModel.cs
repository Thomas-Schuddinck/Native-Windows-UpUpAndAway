using Microsoft.AspNetCore.SignalR.Client;
using Shared.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.ComponentModel;
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
            hubConnection = new HubConnectionBuilder().WithUrl("http://localhost:5000/chatHub").Build();
            hubConnection.On<string, string>("ReceiveMessage", (name, message) =>
            {
                Chat.Add(new PrivateMessage(LoginSingleton.passenger, message));
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
