using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDatabaseApp.Model;

namespace BookingDatabaseApp.Persistency
{
    class BookingPersistencyService
    {
        private static readonly ApiClient<Booking> ApiClient = new ApiClient<Booking>("api/Bookings");

        public static async Task<List<Booking>> LoadBookingAsync()
        {
            return new List<Booking>(await ApiClient.Get());
        }

        public static async void SaveBookingAsync(Booking booking)
        {
            await ApiClient.Post(booking);
        }

        public static async void UpdateBookingAsync(Booking booking)
        {
            await ApiClient.Update(booking.Booking_id, booking);
        }

        public static async void DeleteBookingAsync(Booking booking)
        {
            await ApiClient.Delete(booking.Booking_id);
        }
    }
}
