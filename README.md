# Native-Windows-UpUpAndAway

This app is made for the *Native apps 2: mobile apps voor Windows* course.


# Setup

### Database
The default connection string (.\\sqlexpress) should make connection to your local instance of SQLServer and create the database there. If using a different kind of setup.edit the connection string to connect to your own database setup.

### Packages
All NuGet packages will be automatically installed when building and running the project for the first time.

### Startup
To start up both the API and the frontend app, you may need to configure your solution properties. Under the solution, select "Properties", "Common Properties", "Startup Project". Select "Multiple startup projects". 'UpUpAndAwayApp' and 'API' should be started, in that order. The 'Shared' project should be set to 'None'. 
Starting the project will then be as simple as clicking "Start".

# Application

### Structure
The application features 2 modes: Passenger and Personel. In a real app, this would be selected based on the device. In this case, the user can select them from the first screen.

### Passenger Screen
Passengers can choose from a variety of options. BY default, they will be information about their flight. They can also watch films and series, listen to a selection of excellent songs, order food and drinks, chat with other passengers in their group and even play games with eachother!
Passengers are required to log in. This is done with their Passenger ID (see table below).

### Personel Screen
Personel can do plenty of things. They can receive and handle the orders placed by passengers, change the price of items and change the allocated seat of a Passenger (both swapping 2 Passengers and placing him or her in an empty seat).
The personal screen is shared between all personel.

# Data

### Passengers

| First Name | Last Name | Passenger ID | Group ID |
|:--------------|:--------------|:---:|:---:|
| Thor | Odinson | 1 | 1 |
| Natasha | Romanof| 2 | 1 |
| Clint | Barton | 3 | 1 |
| Bruce | Banner | 4 | 2 |
| Steve | Rogers | 5 | 2 |
| Tony | Stark | 6 | 2 |
