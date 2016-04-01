using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDatabaseApp.Model;

namespace BookingDatabaseApp.Persistency
{
    class GuestPersistencyService
    {
        private static readonly ApiClient<Guest> ApiClient = new ApiClient<Guest>("api/Guests");

        public static async Task<List<Guest>> LoadGuestAsync()
        {
            return new List<Guest>(await ApiClient.Get());
        }

        public static async void SaveGuestAsync(Guest guest)
        {
            await ApiClient.Post(guest);
        }

        public static async void UpdateGuestAsync(Guest guest)
        {
            await ApiClient.Update(guest.Guest_No, guest);
        }

        public static async void DeleteGuestAsync(Guest guest)
        {
            await ApiClient.Delete(guest.Guest_No);
        }
    }
}
