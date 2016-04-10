using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabaseApp.DTO
{
    class DTOBookingsRooms
    {
        public int Booking_id { get; set; }
        public DateTime Date_From { get; set; }
        public DateTime Date_To { get; set; }
        public int Room_No { get; set; }
        //public int Hotel_No { get; set; }
        public string Types { get; set; }
        public double? Price { get; set; }

        public DTOBookingsRooms(int bookingId, DateTime dateFrom, DateTime dateTo, int roomNo, string types, double? price)
        {
            Booking_id = bookingId;
            Date_From = dateFrom;
            Date_To = dateTo;
            Room_No = roomNo;
            //Hotel_No = hotelNo;
            Types = types;
            Price = price;
        }
        public override string ToString()
        {
            return $"BookingId: {Booking_id}, DateFrom: {Date_From}, DateTo: {Date_To}, Room_No: {Room_No},Types: {Types}, Price: {Price}";
        }
    }
}
