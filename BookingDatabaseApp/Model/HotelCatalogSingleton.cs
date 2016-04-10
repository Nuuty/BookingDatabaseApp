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
        
        public List<Hotel> Hotellist { get; set; }
        private static readonly HotelCatalogSingleton _instance = new HotelCatalogSingleton();

        public static HotelCatalogSingleton Instance
        {
            get { return _instance; }
        }
        #region Constructor
        public HotelCatalogSingleton()
        {
            Hotellist = new List<Hotel>();
            LoadHotelAsync();
        } 
        #endregion

        #region Crud Methods
        public async void LoadHotelAsync()
        {
            var hotels = await HotelPersistencyService.LoadHotelAsync();
            if (hotels != null)
            {
                foreach (var hotel in hotels)
                {
                    Hotellist.Add(hotel);
                }
            }
        }
        #endregion

    }
}
