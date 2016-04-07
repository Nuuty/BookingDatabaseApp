namespace BookingDatabaseApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class RoomsGuests
    {
        public double? Price { get; set; }

        public string Types { get; set; }

        public string Hnavn { get; set; }

        public string Gnavn { get; set; }

        public int Room_no { get; set; }

        public RoomsGuests(double? price, string types, string hnavn, string gnavn, int roomNo)
        {
            Price = price;
            Types = types;
            Hnavn = hnavn;
            Gnavn = gnavn;
            Room_no = roomNo;
        }

        public override string ToString()
        {
            return $"Price: {Price}, Types: {Types}, Hnavn: {Hnavn}, Gnavn: {Gnavn}, Room_no: {Room_no}";
        }
    }

}
