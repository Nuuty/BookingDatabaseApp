namespace BookingDatabaseApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Room
    {
        public Room()
        {
            Booking = new HashSet<Booking>();
        }
        public int Room_No { get; set; }
        public int Hotel_No { get; set; }
        public string Types { get; set; }
        public double? Price { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
