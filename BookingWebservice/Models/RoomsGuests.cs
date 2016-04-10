namespace BookingWebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RoomsGuests
    {
        public double? Price { get; set; }

        [StringLength(1)]
        public string Types { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string Hnavn { get; set; }

        [StringLength(30)]
        public string Gnavn { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Room_no { get; set; }
    }
}
