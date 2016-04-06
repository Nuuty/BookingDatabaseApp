namespace BookingDatabaseApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Hotel
    {
        public Hotel()
        {
            
        }

        public int Hotel_No { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Room> Room { get; set; }

        public Hotel(int hotelNo, string name, string address, ICollection<Room> room)
        {
            Hotel_No = hotelNo;
            Name = name;
            Address = address;
            Room = room;
        }

        public override string ToString()
        {
            return $"Hotel_No: {Hotel_No}, Name: {Name}, Address: {Address}, Room: {Room}";
        }
    }
}
