using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpUpAndAwayApp.ViewModels
{

    class PersonnelChatViewModel : INotifyPropertyChanged
    {
        public HubConnection hubConnection;
        public ObservableCollection<string> passengers { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public PersonnelChatViewModel()
        {
            passengers = new ObservableCollection<string>();
            hubConnection = new HubConnectionBuilder().WithUrl("http://localhost:5000/chatHub").WithAutomaticReconnect().Build();

            hubConnection.On<IEnumerable<string>>("SendPassengers", (passengers) =>
            {
                this.passengers = new ObservableCollection<string>(passengers);
                //passengers.ToList().ForEach(i => this.passengers = new ObservableCollection<string>(passengers));
            });
        }

        public async Task SendWarningToPassenger(string message, string person)
        {
            await hubConnection.InvokeAsync("SendWarningToPassenger", person, message);
        }

        public async Task SendWarning(string message)
        {
            await hubConnection.InvokeAsync("SendWarning", message);
        }

        public async Task Disconnect()
        {
            await hubConnection.StopAsync();
        }

        public async Task Connect()
        {
            await hubConnection.StartAsync();
        }

        public async Task GetPassengers()
        {
            await hubConnection.InvokeAsync("GetPassengers");
        }
    }
}
