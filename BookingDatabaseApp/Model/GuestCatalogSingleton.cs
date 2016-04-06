using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDatabaseApp.Persistency;

namespace BookingDatabaseApp.Model
{
    class GuestCatalogSingleton
    {
        
        public List<Guest> Guestlist { get; set; }
        private static readonly GuestCatalogSingleton _instance = new GuestCatalogSingleton();

        public static GuestCatalogSingleton Instance
        {
            get { return _instance; }
        }


        public GuestCatalogSingleton()
        {
            
            Guestlist = new List<Guest>();
            LoadGuestAsync();
        }
        public async void LoadGuestAsync()
        {
            var guestlist = await GuestPersistencyService.LoadGuestAsync();
            if (guestlist != null)
            {
                foreach (var guest in guestlist)
                {
                    Guestlist.Add(guest);
                }
            }
        }
    }
}
