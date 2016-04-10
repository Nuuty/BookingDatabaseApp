using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BookingDatabaseApp.Model;

namespace BookingDatabaseApp.Persistency
{
    internal class HotelPersistencyService
    {
        private static readonly ApiClient<Hotel> ApiClient = new ApiClient<Hotel>("api/Hotels");

        public static async Task<List<Hotel>> LoadHotelAsync()
        {
            return new List<Hotel>(await ApiClient.Get());
        }

        public static async void SaveHotelAsync(Hotel hotel)
        {
            await ApiClient.Post(hotel);
        }

        public static async void UpdateHotelAsync(Hotel hotel)
        {
            await ApiClient.Update(hotel.Hotel_No,hotel);
        }

        public static async void DeleteHotelAsync(Hotel hotel)
        {
            await ApiClient.Delete(hotel.Hotel_No);
        }
    }
}
