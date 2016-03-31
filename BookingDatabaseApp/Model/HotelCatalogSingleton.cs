using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDatabaseApp.Persistency;

namespace BookingDatabaseApp.Model
{
    class HotelCatalogSingleton
    {
        public ObservableCollection<Hotel> Hoteller { get; set; }
        private static readonly HotelCatalogSingleton _instance = new HotelCatalogSingleton();

        public static HotelCatalogSingleton Instance
        {
            get { return _instance; }
        }
        #region Constructor
        public HotelCatalogSingleton()
        {
            Hoteller = new ObservableCollection<Hotel>();
            LoadHotelAsync();
        } 
        #endregion

        #region Crud Methods
        public async void LoadHotelAsync()
        {
            var hotels = await PersistencyService.LoadHotels();
            if (hotels != null)
            {
                foreach (var hotel in hotels)
                {
                    Hoteller.Add(hotel);
                }
            }
        }

        public void SaveHotelAsync(Hotel hotel)
        {
            Hoteller.Add(hotel);
            PersistencyService.SaveHotel(hotel);

        }

        public void DeleteHotelAsync(Hotel hotel)
        {
            Hoteller.Remove(hotel);
            PersistencyService.DeleteHotel(hotel);
        }

        public void UpdateHotelAsync(Hotel hotel)
        {
            Hoteller.Add(hotel);
            PersistencyService.UpdateHotel(hotel);
        }
        #endregion

    }
}
