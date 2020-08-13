using Shared.Models;
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
            //context.Database.EnsureDeleted();
            if (context.Database.EnsureCreated())
            {
                SeedData();
                SeedPassengers();
            }

        }

        private void SeedData()
        {
            context.Consumables.AddRange(new[] {
                    new Consumable(16.5, "Burger", "Een heerlijke burger op grootmoeder's wijze", 0, "https://upload.wikimedia.org/wikipedia/commons/4/4d/Cheeseburger.jpg"),
                    new Consumable(14.5, "Spaghetti Bolognaise", "Een echte Italiaanse spaghetti", 0, "https://banner2.cleanpng.com/20180423/qvw/kisspng-bolognese-sauce-pizza-pasta-lasagne-buffalo-wing-spagetti-pasta-5ade9a975ca656.4221295815245380073795.jpg"),
                    new Consumable(3.5, "Cola", "Een frisse Coca Cola", 0, "https://www.prikentik.be/media/catalog/product/cache/23d9da881b836928ceaa9fe24f71827f/c/o/coca-cola-orginal-pet-50cl.png"),
                    new Consumable(3.5, "Cola Zero", "Een frisse Coca Cola Zero", 0, "https://upload.wikimedia.org/wikipedia/commons/thumb/0/02/Coca_Cola_Zero_02.jpg/266px-Coca_Cola_Zero_02.jpg"),
                    new Consumable(4, "Fanta", "Een frisse Fanta", 0.25, "https://images.quickoffice.nl/002/600x450/Frisdrank-Fanta-Orange-petfles-0-50l-(c)897067.jpg"),
                    new Consumable(5, "Jupiler", "Een verkoelende Jupiler", 0, "https://cdn.webshopapp.com/shops/19852/files/298224123/brouwerij-ab-inbev-jupiler.jpg"),
                    new Consumable(3, "Paprika Chips", "Paprika chips van Lays", 0, "https://thysshop.be/9314-thickbox_default/Lays-Chips-Paprika-Stuk-85-g.jpg"),
                    new Consumable(3, "Gezouten Chips", "Gezouten chips van Lays", 0, "https://thysshop.be/8786-large_default/Lays-Chips-Naturel-Stuk-40-g.jpg")
                });
            context.Songs.AddRange(new[] {
                    new Song("We are number one", "LazyTown", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/WeAreNumberOne.mp3", "http://localhost:5000/Data/Resources/Img/WeAreNumberOne.jpg"),
                    new Song("Sandstorm", "Darude", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/DarudeSandstorm.mp3", "http://localhost:5000/Data/Resources/Img/DarudeSandstorm.jpg"),
                    new Song("We are number one", "LazyTown", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/WeAreNumberOne.mp3", "http://localhost:5000/Data/Resources/Img/WeAreNumberOne.jpg"),
                    new Song("Sandstorm", "Darude", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/DarudeSandstorm.mp3", "http://localhost:5000/Data/Resources/Img/DarudeSandstorm.jpg"),
                    new Song("We are number one", "LazyTown", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/WeAreNumberOne.mp3", "http://localhost:5000/Data/Resources/Img/WeAreNumberOne.jpg"),
                    new Song("Sandstorm", "Darude", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/DarudeSandstorm.mp3", "http://localhost:5000/Data/Resources/Img/DarudeSandstorm.jpg"),
                    new Song("We are number one", "LazyTown", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/WeAreNumberOne.mp3", "http://localhost:5000/Data/Resources/Img/WeAreNumberOne.jpg"),
                    new Song("Sandstorm", "Darude", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/DarudeSandstorm.mp3", "http://localhost:5000/Data/Resources/Img/DarudeSandstorm.jpg"),
                    new Song("We are number one", "LazyTown", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/WeAreNumberOne.mp3", "http://localhost:5000/Data/Resources/Img/WeAreNumberOne.jpg"),
                    new Song("Sandstorm", "Darude", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/DarudeSandstorm.mp3", "http://localhost:5000/Data/Resources/Img/DarudeSandstorm.jpg"),
                    new Song("We are number one", "LazyTown", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/WeAreNumberOne.mp3", "http://localhost:5000/Data/Resources/Img/WeAreNumberOne.jpg"),
                    new Song("Sandstorm", "Darude", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/DarudeSandstorm.mp3", "http://localhost:5000/Data/Resources/Img/DarudeSandstorm.jpg"),
                    new Song("We are number one", "LazyTown", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/WeAreNumberOne.mp3", "http://localhost:5000/Data/Resources/Img/WeAreNumberOne.jpg"),
                    new Song("Sandstorm", "Darude", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/DarudeSandstorm.mp3", "http://localhost:5000/Data/Resources/Img/DarudeSandstorm.jpg"),
                    new Song("We are number one", "LazyTown", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/WeAreNumberOne.mp3", "http://localhost:5000/Data/Resources/Img/WeAreNumberOne.jpg"),
                    new Song("Sandstorm", "Darude", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/DarudeSandstorm.mp3", "http://localhost:5000/Data/Resources/Img/DarudeSandstorm.jpg"),
                    new Song("We are number one", "LazyTown", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/WeAreNumberOne.mp3", "http://localhost:5000/Data/Resources/Img/WeAreNumberOne.jpg"),
                    new Song("Sandstorm", "Darude", "Date", "genre", "http://localhost:5000/Data/Resources/Mp3/DarudeSandstorm.mp3", "http://localhost:5000/Data/Resources/Img/DarudeSandstorm.jpg"),
                }); ;

            context.SaveChanges();
            //Herschreven zodat het op 2 lijntjes past
        }

        private void SeedPassengers()
        {

            #region passengers
            var passenger1 = new Passenger("Tony", "Stark");
            var passenger2 = new Passenger("Steve", "Rogers");
            var passenger3 = new Passenger("Clint", "Barton");
            var passenger4 = new Passenger("ByeBye", "WindowsPhoneSupport");
            var passenger5 = new Passenger("SoMuchFor", "NativeApps");
            var passenger6 = new Passenger("Android", "FTW");

            var seat1 = new Seat { Passenger = passenger1 };
            var seat2 = new Seat { Passenger = passenger2 };
            var seat3 = new Seat { Passenger = passenger3 };
            var seat4 = new Seat { Passenger = passenger4 };
            var seat5 = new Seat { Passenger = passenger5 };
            var seat6 = new Seat { Passenger = passenger6 };
            var seat7 = new Seat();
            var seat8 = new Seat();

            context.Seats.AddRange(new[] { seat1, seat2, seat3, seat4, seat5, seat6 });

            context.Passengers.AddRange(new[] { passenger1, passenger2, passenger3, passenger4, passenger5, passenger6 });

            context.PassengerParties.AddRange(
                new[]{
                new PassengerParty() {Passengers = { passenger1, passenger2, passenger6 }},
                new PassengerParty() {Passengers = {passenger3, passenger4, passenger5}}
                }
                );

           

            context.SaveChanges();


            //Need different call to force proper alignment of ID's (passenger 1 in seat 1)


            context.Seats.AddRange(new[] { seat7, seat8 });
            context.SaveChanges();

            #endregion
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