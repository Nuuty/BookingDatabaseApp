using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabaseApp.Persistency
{
    class DTOGetter
    {
        private static readonly ApiClient<RoomsGuests> ApiClient = new ApiClient<RoomsGuests>("api/RoomsGuests");

        public static async Task<List<RoomsGuests>> LoadRoomsGuestsAsync()
        {
            return new List<RoomsGuests>(await ApiClient.Get());
        }
    }
}
