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
        public ObservableCollection<Guest> Guests { get; set; }
        private static readonly GuestCatalogSingleton _instance = new GuestCatalogSingleton();

        public static GuestCatalogSingleton Instance
        {
            get { return _instance; }
        }


        public GuestCatalogSingleton()
        {
            Guests = new ObservableCollection<Guest>();
        }
        public async void LoadGuestAsync()
        {
            var guestlist = await GuestPersistencyService.LoadGuestAsync();
            if (guestlist != null)
            {
                foreach (var guest in guestlist)
                {
                    Guests.Add(guest);
                }
            }
        }

        public void SaveGuestAsync(Guest guest)
        {
            Guests.Add(guest);
            GuestPersistencyService.SaveGuestAsync(guest);

        }

        public void DeleteGuestAsync(Guest guest)
        {
            Guests.Remove(guest);
            GuestPersistencyService.DeleteGuestAsync(guest);
        }

        public void UpdateGuestAsync(Guest guest)
        {
            Guests.Add(guest);
            GuestPersistencyService.UpdateGuestAsync(guest);
        }
    }
}
