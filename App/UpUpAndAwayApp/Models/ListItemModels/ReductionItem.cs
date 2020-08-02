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
    public class ReductionItem
    {
        public int reduction;
        public Consumable Consumable { get; set; }

        public int Reduction
        {
            get => reduction;
            set
            {
                reduction = value;
                OnPropertyChanged();
            }
        }

        public ReductionViewModel WebshopViewModel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ReductionItem(Consumable consumable, ReductionViewModel webshopViewModel)
        {
            Consumable = consumable;
            WebshopViewModel = webshopViewModel;
            ResetReduction();
        }

        public void ResetReduction()
        {
            Reduction = 0;
        }

        protected void OnPropertyChanged([CallerMemberName] string amount = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(amount));
        }
    }
}
