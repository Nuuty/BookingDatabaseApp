using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using BookingWebservice.Models;

namespace BookingDatabaseApp.Persistency
{
    class PersistencyClass
    {
        private const string ServerUri = "http://bookingwebservice20160412033058.azurewebsites.net/";
        private static HttpClientHandler GetHandler()
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = true };
            return handler;
        }
        private static void SetClientSettingsToJson(HttpClient client)
        {
            // client.BaseAddress = new Uri(ServerUri);
            client.BaseAddress = new Uri(ServerUri);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static async Task<List<HotelsRooms>> GHotelsRooms(String name)
        {
            using (var client = new HttpClient(GetHandler()))
            {
                SetClientSettingsToJson(client);
                try
                {
                    var response = await client.GetAsync("api/AllRooms/" + name);
                    if (response.IsSuccessStatusCode)
                    {
                        List<HotelsRooms> HotelsRooms = await response.Content.ReadAsAsync<List<HotelsRooms>>();
                        return HotelsRooms;
                    }
                }
                catch (Exception ex)
                {
                    await new MessageDialog(ex.Message).ShowAsync();
                }
                return null;
            }
        }
    }
}
