using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Shared.Models;
using UpUpAndAwayApp.ViewModels;

namespace UpUpAndAwayApp.Models.ListItemModels
{
    public class ReductionItem : INotifyPropertyChanged
    {
        private double reduction;
        public Consumable Consumable { get; set; }

        public double Reduction
        {
            get => reduction;
            set
            {
                reduction = value;
                OnPropertyChanged();
            }
        }

        public ReductionViewModel ViewModel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ReductionItem(Consumable consumable, ReductionViewModel vm)
        {
            Consumable = consumable;
            ViewModel = vm;
            Reduction = consumable.Reduction;
        }



        protected void OnPropertyChanged([CallerMemberName] string amount = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(amount));
        }
    }
}
