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
    class RoomsPersistencyService
    {
        public static async Task<List<Room>> LoadRooms()
        {
            const string serverUrl = "http://localhost:1337";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Rooms").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var Rooms = response.Content.ReadAsAsync<IEnumerable<Room>>().Result;
                        return Rooms.ToList();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return null;

            }
        }
        public static async void SaveRoom(Room Room)
        {
            const string serverUrl = "http://localhost:1337";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PostAsJsonAsync("api/Rooms", Room).Result;
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        public static async void DeleteRoom(Room Room)
        {
            const string serverUrl = "http://localhost:1337";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.DeleteAsync("api/Rooms/" + Room.Room_No);
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public static async void UpdateRoom(Room Room)
        {
            const string serverUrl = "http://localhost:1337";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PutAsJsonAsync("api/Rooms/" + Room.Room_No, Room).Result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
