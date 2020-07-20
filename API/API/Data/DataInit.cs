using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataInit
    {
        private readonly Context context;

        public DataInit(Context context)
        {
            this.context = context;
        }

        public async Task InitializeData()
        {

            context.Database.EnsureDeleted();
            if (context.Database.EnsureCreated())
            {
                SeedData();
            }

        }

        private void SeedData()
        {
            context.Consumables.AddRange(new[] {
                    new Consumable(16.5, "Burger", "Een heerlijke burger op grootmoeder's wijze", 0, ""),
                    new Consumable(14.5, "Spaghetti Bolognaise", "Een echte Italiaanse spaghetti", 0, ""),
                    new Consumable(3.5, "Cola", "Een frisse Coca Cola", 0, ""),
                    new Consumable(3.5, "Cola Zero", "Een frisse Coca Cola Zero", 0, ""),
                    new Consumable(4, "Fanta", "Een frisse Fanta", 0, ""),
                    new Consumable(5, "Jupiler", "Een verkoelende Jupiler", 0, ""),
                    new Consumable(3, "Paprika Chips", "Paprika chips van Lays", 0, ""),
                    new Consumable(3, "Gezouten Chips", "Gezouten chips van Lays", 0, "")
                });

            #region passengers
            Passenger passenger1 = new Passenger("Tony", "Stark");
            Passenger passenger2 = new Passenger("Steven", "Rogers");
            Passenger passenger3 = new Passenger("Clint", "Barton");

            context.Passenger.Add(passenger1);
            context.Passenger.Add(passenger2);
            context.Passenger.Add(passenger3);

            PassengerParty p1 = new PassengerParty() { Passengers = { passenger1, passenger2 } };

            context.PassengerParties.Add(p1);
            #endregion

            context.SaveChanges();
            //Herschreven zodat het op 2 lijntjes past
        }
    }
}

#region old code
/*
//Consumable burger = new Consumable(16.5, "Burger", "Een heerlijke burger op grootmoeder's wijze", 0, "");
//Consumable spaghetti = new Consumable(14.5, "Spaghetti Bolognaise", "Een echte Italiaanse spaghetti", 0, "");
//Consumable cola = new Consumable(3.5, "Cola", "Een frisse Coca Cola", 0, "");
//Consumable colaZero = new Consumable(3.5, "Cola Zero", "Een frisse Coca Cola Zero", 0, "");
//Consumable fanta = new Consumable(4, "Fanta", "Een frisse Fanta", 0, "");
//Consumable jupiler = new Consumable(5, "Jupiler", "Een verkoelende Jupiler", 0, "");
//Consumable chipsPaprika = new Consumable(3, "Paprika Chips", "Paprika chips van Lays", 0, "");
//Consumable chipsZout = new Consumable(3, "Gezouten Chips", "Gezouten chips van Lays", 0, "");

//context.Consumables.Add(burger);
//context.Consumables.Add(spaghetti);
//context.Consumables.Add(cola);
//context.Consumables.Add(fanta);
//context.Consumables.Add(colaZero);
//context.Consumables.Add(jupiler);
//context.Consumables.Add(chipsPaprika);
//context.Consumables.Add(chipsZout);
//context.SaveChanges();
*/
#endregion