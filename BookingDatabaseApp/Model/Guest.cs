namespace BookingDatabaseApp.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Guest
    {
        public Guest()
        {
            Booking = new HashSet<Booking>();
        }
        public int Guest_No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
