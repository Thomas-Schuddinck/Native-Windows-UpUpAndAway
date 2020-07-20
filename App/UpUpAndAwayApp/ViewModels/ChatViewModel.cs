using API.Models;
using System;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.SignalR.Client;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel;

namespace UpUpAndAwayApp.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        public HubConnection hubConnection; private string _name;
        private string _message;
        public ObservableCollection<PrivateMessage> Chat;
        private bool _isConnected;

        public event PropertyChangedEventHandler PropertyChanged;

        public ChatViewModel()
        {
            Chat = new ObservableCollection<PrivateMessage>();
            hubConnection = new HubConnectionBuilder().WithUrl("http://localhost:5000/chatHub").Build();
            hubConnection.On<string, string, string>("ReceiveMessage", (firstname, lastname, message) =>
            {
                Passenger p = new Passenger(firstname, lastname, 1);
                Chat.Add(new PrivateMessage(p, message, DateTime.Now));
            });
        }

        public async Task Connect()
        {
            await hubConnection.StartAsync();
            _isConnected = true;
        }

        public async Task SendMessage(Passenger p, string message)
        {
            await hubConnection.InvokeAsync("SendMessage", p.FirstName, p.LastName, message);
        }

        public async Task Disconnect()
        {
            await hubConnection.StopAsync();
        }
    }
}
