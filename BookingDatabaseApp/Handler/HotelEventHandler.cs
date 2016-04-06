using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BookingDatabaseApp.Model;
using BookingDatabaseApp.Persistency;

namespace BookingDatabaseApp.Handler
{
    class HotelEventHandler
    {
        public ViewModel.ViewModel HotelVM { get; set; }

        public HotelEventHandler(ViewModel.ViewModel hotelVm)
        {
            HotelVM = hotelVm;
        }

        public void CreateHotel()
        {
            HotelVM.Catalog.SaveHotelAsync(new Hotel(HotelVM.HotelNo, HotelVM.HotelName, HotelVM.HotelAddress, null));
            ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
        }

        public void DeleteHotel()
        {
            HotelVM.Catalog.DeleteHotelAsync(HotelVM.SelectedItem);
        }

        public void UpdateHotel()
        {
            HotelVM.Catalog.UpdateHotelAsync(HotelVM.SelectedItem);
            ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
            HotelVM.Catalog.Hoteller.Clear();
            HotelVM.Catalog.LoadHotelAsync();
        }
        public async void HotelsinRoskilde()
        {
            HotelVM.Catalog.Hoteller.Clear();
            var hotels = await HotelPersistencyService.LoadHotelAsync();
            await Task.Delay(200);
            var query = from hotel in hotels where hotel.Address.Contains("Roskilde") select hotel;

            foreach (var hotel in query)
            {
                HotelVM.Catalog.Hoteller.Add(hotel);
            }
        }

        public async void LoadAllHotelRooms()
        {
            var hotels = await HotelPersistencyService.LoadHotelAsync();
            var rooms = await RoomPersistencyService.LoadRoomAsync();
            await Task.Delay(200);
            var query = from room in hotels
                        select room;
            foreach (var element in query)
            {
                //AllHotelAndRooms.Add(element);
            }

        }
    }
}
