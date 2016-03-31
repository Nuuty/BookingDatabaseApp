using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BookingDatabaseApp.Model;

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
    }
}
