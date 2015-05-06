using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponents.Data
{
    public static class DataGenerator
    {
        public static List<Hotel> GenerateHotels()
        {
            var hotels = new List<Hotel>();

            Hotel hotel = new Hotel();
            hotel.Name = "Adriano";
            hotel.Street = "Happy street 5";
            hotel.City = "Konstanz";
            hotel.Lat = 47.7083;
            hotel.Lon = 9.1517;
            hotels.Add(hotel);

            hotel = new Hotel();
            hotel.Name = "In Barry";
            hotel.Street = "Longway 12";
            hotel.City = "Vaduz";
            hotel.Lat = 47.1430;
            hotel.Lon = 9.5216;
            hotels.Add(hotel);

            hotel = new Hotel();
            hotel.Name = "Margaret";
            hotel.Street = "Charlie ave. 58";
            hotel.City = "Lyon";
            hotel.Lat = 45.7789;
            hotel.Lon = 4.8451;
            hotels.Add(hotel);

            hotel = new Hotel();
            hotel.Name = "House Dom";
            hotel.Street = "Jeanne d'Ark ave. 176";
            hotel.City = "Nantes";
            hotel.Lat = 47.2975;
            hotel.Lon = -1.5457;
            hotels.Add(hotel);

            hotel = new Hotel();
            hotel.Name = "Lord hotel";
            hotel.Street = "Wellington str. 98";
            hotel.City = "Sheffield";
            hotel.Lat = 53.3772;
            hotel.Lon = -1.4636;
            hotels.Add(hotel);

            return hotels;
        }
    }
}
