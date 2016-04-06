using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using BookingDatabaseApp.Annotations;
using BookingDatabaseApp.DTO;
using BookingDatabaseApp.Model;
using BookingDatabaseApp.Persistency;
using Eventmaker.Common;

namespace BookingDatabaseApp.Handler
{
    class HotelEventHandler
    {
        public ViewModel.ViewModel HotelVM { get; set; }

        #region ICommands
        private ICommand _hotelsinRoskildeCommand;

        public ICommand HotelsinRoskildeCommand
        {
            get
            {
                return _hotelsinRoskildeCommand ??
                       (_hotelsinRoskildeCommand = new RelayCommand(HotelsinRoskilde));
            }
        }

        private ICommand _bookingsandrooms;

        public ICommand BookingandRooms
        {
            get { return _bookingsandrooms ?? (_bookingsandrooms = new RelayCommand(TodaysBookedRooms)); }
        }
        private ICommand _hotelsandrooms;

        public ICommand Hotelsandrooms
        {
            get { return _hotelsandrooms ?? (_hotelsandrooms = new RelayCommand(LoadAllHotelRooms)); }
        }
        private ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(DeleteHotel));
            }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new RelayCommand(CreateHotel)); }
        }
        private ICommand _updateCommand;
        private DateTime _chosenTime;

        public ICommand UpdateCommand
        {
            get { return _updateCommand ?? (_updateCommand = new RelayCommand(UpdateHotel)); }
        }
        #endregion
        private static Hotel _selectedItem;
        public Hotel SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; }
        }

        private DateTimeOffset _chosentime;

        public DateTimeOffset Chosentime
        {
            get { return _chosentime; }
            set { _chosentime = value;}
        }

        public HotelEventHandler(ViewModel.ViewModel hotelVm)
        {
            HotelVM = hotelVm;
        }

        public void CreateHotel()
        {
            SaveHotelAsync(new Hotel(HotelVM.HotelNo, HotelVM.HotelName, HotelVM.HotelAddress, null));
            ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
        }

        public void DeleteHotel()
        {
            DeleteHotelAsync(SelectedItem);
        }

        public void UpdateHotel()
        {
            UpdateHotelAsync(SelectedItem);
            ((Frame)Window.Current.Content).Navigate(typeof(MainPage));
            HotelVM.Hoteller.Clear();
            HotelVM.HotelCatalog.LoadHotelAsync();
        }
        public async void HotelsinRoskilde()
        {
            HotelVM.Hoteller.Clear();
            var hotels = await HotelPersistencyService.LoadHotelAsync();
            await Task.Delay(200);
            var query = from hotel in hotels where hotel.Address.Contains("Roskilde") select hotel;

            foreach (var hotel in query)
            {
                HotelVM.Hoteller.Add(hotel);
            }
        }

        public async void LoadAllHotelRooms()
        {
            HotelVM.HotelsRooms.Clear();
            var hotels = HotelVM.HotelCatalog.Hotellist;
            var rooms = HotelVM.RoomCatalog.Roomlist;
            await Task.Delay(200);
            var query = from room in rooms
                        join hotel in hotels on room.Hotel_No equals hotel.Hotel_No
                        where room.Hotel_No == SelectedItem.Hotel_No
                        select new {hotel.Hotel_No,hotel.Name,hotel.Address,room.Room_No,room.Types,room.Price};
            foreach (var x in query)
            {
                HotelVM.HotelsRooms.Add(new DTOHotelsRooms(x.Hotel_No,x.Name,x.Address,x.Room_No,x.Types,x.Price));
            }

        }

        public async void TodaysBookedRooms()
        {
            HotelVM.BookingsRooms.Clear();
            var rooms = HotelVM.RoomCatalog.Roomlist;
            var bookings = HotelVM.BookingCatalog.Bookinglist;
            await Task.Delay(200);
            var query = from booking in bookings
                join room in rooms on booking.Room_No equals room.Room_No
                where booking.Date_From <= Chosentime && booking.Date_To >= Chosentime
                select new {booking.Booking_id,booking.Date_From,booking.Date_To,room.Room_No,room.Types,room.Price};
            foreach (var x in query)
            {
                HotelVM.BookingsRooms.Add(new DTOBookingsRooms(x.Booking_id,x.Date_From,x.Date_To,x.Room_No,x.Types,x.Price));
            }
        }

        #region CRUD Methods
        public async void LoadHotelAsync()
        {
            var hotels = HotelVM.HotelCatalog.Hotellist;
            if (hotels != null)
            {
                foreach (var hotel in hotels)
                {
                    HotelVM.Hoteller.Add(hotel);
                }
            }
        }
        public void SaveHotelAsync(Hotel hotel)
        {
            HotelVM.Hoteller.Add(hotel);
            HotelPersistencyService.SaveHotelAsync(hotel);

        }

        public void DeleteHotelAsync(Hotel hotel)
        {
            HotelVM.Hoteller.Remove(hotel);
            HotelPersistencyService.DeleteHotelAsync(hotel);
        }

        public void UpdateHotelAsync(Hotel hotel)
        {
            HotelVM.Hoteller.Add(hotel);
            HotelPersistencyService.UpdateHotelAsync(hotel);
        }
        public void SaveBookingAsync(Booking booking)
        {
            HotelVM.BookingsOC.Add(booking);
            BookingPersistencyService.SaveBookingAsync(booking);

        }

        public void DeleteBookingAsync(Booking booking)
        {
            HotelVM.BookingsOC.Remove(booking);
            BookingPersistencyService.DeleteBookingAsync(booking);
        }

        public void UpdateBookingAsync(Booking booking)
        {
            HotelVM.BookingsOC.Add(booking);
            BookingPersistencyService.UpdateBookingAsync(booking);
        }
        public async void LoadRoomsAsync()
        {
            var rooms = await RoomPersistencyService.LoadRoomAsync();
            if (rooms != null)
            {
                foreach (var room in rooms)
                {
                    HotelVM.RoomsOC.Add(room);
                }
            }
        }

        public void SaveRoomAsync(Room room)
        {
            HotelVM.RoomsOC.Add(room);
            RoomPersistencyService.SaveRoomAsync(room);

        }

        public void DeleteRoomAsync(Room Room)
        {
            HotelVM.RoomsOC.Remove(Room);
            RoomPersistencyService.DeleteRoomAsync(Room);
        }

        public void UpdateRoomAsync(Room Room)
        {
            HotelVM.RoomsOC.Add(Room);
            RoomPersistencyService.UpdateRoomAsync(Room);
        }
        public async void LoadGuestAsync()
        {
            var guestlist = await GuestPersistencyService.LoadGuestAsync();
            if (guestlist != null)
            {
                foreach (var guest in guestlist)
                {
                    HotelVM.Guests.Add(guest);
                }
            }
        }

        public void SaveGuestAsync(Guest guest)
        {
            HotelVM.Guests.Add(guest);
            GuestPersistencyService.SaveGuestAsync(guest);

        }

        public void DeleteGuestAsync(Guest guest)
        {
            HotelVM.Guests.Remove(guest);
            GuestPersistencyService.DeleteGuestAsync(guest);
        }

        public void UpdateGuestAsync(Guest guest)
        {
            HotelVM.Guests.Add(guest);
            GuestPersistencyService.UpdateGuestAsync(guest);
        } 
        #endregion
    }
}
