using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDatabaseApp.Model;

namespace BookingDatabaseApp.Persistency
{
    class RoomPersistencyService
    {
        private static readonly ApiClient<Room> ApiClient = new ApiClient<Room>("api/Rooms");

        public static async Task<List<Room>> LoadRoomAsync()
        {
            return new List<Room>(await ApiClient.Get());
        }

        public static async void SaveRoomAsync(Room room)
        {
            await ApiClient.Post(room);
        }

        public static async void UpdateRoomAsync(Room room)
        {
            await ApiClient.Update(room.Room_No, room);
        }

        public static async void DeleteRoomAsync(Room room)
        {
            await ApiClient.Delete(room.Room_No);
        }
    }
}
