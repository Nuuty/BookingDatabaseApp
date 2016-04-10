namespace BookingWebservice
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelGuestsContext : DbContext
    {
        public HotelGuestsContext()
            : base("name=HotelGuestsContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<RoomsGuests> RoomsGuests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomsGuests>()
                .Property(e => e.Types)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RoomsGuests>()
                .Property(e => e.Hnavn)
                .IsUnicode(false);

            modelBuilder.Entity<RoomsGuests>()
                .Property(e => e.Gnavn)
                .IsUnicode(false);
        }
    }
}
