using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDatabaseApp.Persistency;

namespace BookingDatabaseApp.Model
{
    class BookingCatalogSingleton
    {
        
        public List<Booking> Bookinglist { get; set; } 
        private static readonly BookingCatalogSingleton _instance = new BookingCatalogSingleton();

        public static BookingCatalogSingleton Instance
        {
            get { return _instance; }
        }

        public BookingCatalogSingleton()
        {
            
            Bookinglist = new List<Booking>();
            LoadBookingAsync();
        }

        public async void LoadBookingAsync()
        {
            var bookinglist = await BookingPersistencyService.LoadBookingAsync();
            if (bookinglist != null)
            {
                foreach (var booking in bookinglist)
                {
                    Bookinglist.Add(booking);
                }
            }
        }

        
    }
}
