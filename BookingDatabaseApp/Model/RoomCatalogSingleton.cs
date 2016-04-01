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
        public ObservableCollection<Room> RoomsOC { get; set; }
        private static readonly RoomCatalogSingleton _instance = new RoomCatalogSingleton();

        public static RoomCatalogSingleton Instance
        {
            get { return _instance; }
        }

        public RoomCatalogSingleton()
        {
            RoomsOC = new ObservableCollection<Room>();
        }
        public async void LoadRoomsAsync()
        {
            var rooms = await RoomPersistencyService.LoadRoomAsync();
            if (rooms != null)
            {
                foreach (var room in rooms)
                {
                    RoomsOC.Add(room);
                }
            }
        }

        public void SaveRoomAsync(Room room)
        {
            RoomsOC.Add(room);
            RoomPersistencyService.SaveRoomAsync(room);

        }

        public void DeleteRoomAsync(Room Room)
        {
            RoomsOC.Remove(Room);
            RoomPersistencyService.DeleteRoomAsync(Room);
        }

        public void UpdateRoomAsync(Room Room)
        {
            RoomsOC.Add(Room);
            RoomPersistencyService.UpdateRoomAsync(Room);
        }
    }
}
