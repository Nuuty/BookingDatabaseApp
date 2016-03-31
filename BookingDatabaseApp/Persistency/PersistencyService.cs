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
    class PersistencyService
    {
        public static async Task<List<Hotel>> LoadHotels()
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
                    var response = client.GetAsync("api/hotels").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                        return hotels.ToList();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return null;

            }
        }
        public static async void SaveHotel(Hotel hotel)
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
                    var response = client.PostAsJsonAsync("api/hotels", hotel).Result;
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        public static async void DeleteHotel(Hotel hotel)
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
                    await client.DeleteAsync("api/hotels/" + hotel.Hotel_No);
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public static async void UpdateHotel(Hotel hotel)
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
                    var response = client.PutAsJsonAsync("api/hotels/" + hotel.Hotel_No, hotel).Result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
