using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabaseApp.DTO
{
    class DTOHotelsRooms
    {
        public int Hotel_No { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int Room_No { get; set; }

        public string Types { get; set; }

        public double? Price { get; set; }

        public DTOHotelsRooms(int hotelNo, string name, string address, int roomNo, string types, double? price)
        {
            Hotel_No = hotelNo;
            Name = name;
            Address = address;
            Room_No = roomNo;
            Types = types;
            Price = price;
        }
        public override string ToString()
        {
            return $"Hotel_No: {Hotel_No}, Name: {Name}, Address: {Address}, Room_No: {Room_No}, Types: {Types}, Price: {Price}";
        }
    }
}
