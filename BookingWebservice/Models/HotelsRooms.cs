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
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Hotel_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Address { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Room_No { get; set; }

        [StringLength(1)]
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