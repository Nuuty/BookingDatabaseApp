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
        public ObservableCollection<Booking> BookingsOC { get; set; } 
        private static readonly BookingCatalogSingleton _instance = new BookingCatalogSingleton();

        public static BookingCatalogSingleton Instance
        {
            get { return _instance; }
        }

        public BookingCatalogSingleton()
        {
            BookingsOC = new ObservableCollection<Booking>();
        }
        public async void LoadBookingAsync()
        {
            var Bookinglist = await BookingPersistencyService.LoadBookingAsync();
            if (Bookinglist != null)
            {
                foreach (var booking in Bookinglist)
                {
                    BookingsOC.Add(booking);
                }
            }
        }

        public void SaveBookingAsync(Booking booking)
        {
            BookingsOC.Add(booking);
            BookingPersistencyService.SaveBookingAsync(booking);

        }

        public void DeleteBookingAsync(Booking booking)
        {
            BookingsOC.Remove(booking);
            BookingPersistencyService.DeleteBookingAsync(booking);
        }

        public void UpdateBookingAsync(Booking booking)
        {
            BookingsOC.Add(booking);
            BookingPersistencyService.UpdateBookingAsync(booking);
        }
    }
}
