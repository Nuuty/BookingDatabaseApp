using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDatabaseApp.Persistency;

namespace BookingDatabaseApp.Model
{
    class RoomCatalogSingleton
    {
        
        public List<Room> Roomlist { get; set; }
        private static readonly RoomCatalogSingleton _instance = new RoomCatalogSingleton();

        public static RoomCatalogSingleton Instance
        {
            get { return _instance; }
        }

        public RoomCatalogSingleton()
        {
            
            Roomlist = new List<Room>();
            LoadRoomsAsync();
        }
        public async void LoadRoomsAsync()
        {
            var rooms = await RoomPersistencyService.LoadRoomAsync();
            if (rooms != null)
            {
                foreach (var room in rooms)
                {
                    Roomlist.Add(room);
                }
            }
        }
    }
}
