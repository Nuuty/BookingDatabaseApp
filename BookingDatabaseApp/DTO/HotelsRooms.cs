using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookingWebservice.Models
{
    public class HotelsRooms
    {

        public int Hotel_No { get; set; }


        public string Name { get; set; }


        public string Address { get; set; }

        public int Room_No { get; set; }

        public string Types { get; set; }

        public double? Price { get; set; }
        public HotelsRooms()
        {

        }

        public override string ToString()
        {
            return $"Hotel_No: {Hotel_No}, Name: {Name}, Address: {Address}, Room_No: {Room_No}, Types: {Types}, Price: {Price}";
        }
    }
}