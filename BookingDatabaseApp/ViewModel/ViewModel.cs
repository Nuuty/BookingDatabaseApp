using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Appointments;
using Windows.Data.Text;
using BookingDatabaseApp.Annotations;
using BookingDatabaseApp.DTO;
using BookingDatabaseApp.Handler;
using BookingDatabaseApp.Model;
using BookingDatabaseApp.Persistency;
using Eventmaker.Common;

namespace BookingDatabaseApp.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<RoomsGuests> ViewData { get; set; }
        public ObservableCollection<Hotel> Hoteller { get; set; }
        public ObservableCollection<Booking> BookingsOC { get; set; }
        public ObservableCollection<Room> RoomsOC { get; set; }
        public ObservableCollection<Guest> Guests { get; set; }
        public ObservableCollection<DTOHotelsRooms> HotelsRooms { get; set; }
        public ObservableCollection<DTOBookingsRooms> BookingsRooms { get; set; } 
        public HotelCatalogSingleton HotelCatalog { get; } = HotelCatalogSingleton.Instance;
        public RoomCatalogSingleton RoomCatalog { get; } = RoomCatalogSingleton.Instance;
        public BookingCatalogSingleton BookingCatalog { get; } = BookingCatalogSingleton.Instance;
        public GuestCatalogSingleton GuestCatalog { get; } = GuestCatalogSingleton.Instance;
        public int HotelNo
        {
            get { return _Hotel_No; }
            set { _Hotel_No = value;  }
        }

        public string HotelName
        {
            get { return _Hotel_Name; }
            set { _Hotel_Name = value;  }
        }

        public string HotelAddress
        {
            get { return _Hotel_Address; }
            set { _Hotel_Address = value;  }
        }

        private static int _Hotel_No;
        private static String _Hotel_Name;
        private static String _Hotel_Address;
        

        
        public HotelEventHandler HotelHandler { get; set; }

        

        public ViewModel()
        {
           
            HotelHandler = new HotelEventHandler(this);
            Hoteller = new ObservableCollection<Hotel>();
            RoomsOC = new ObservableCollection<Room>();
            BookingsOC = new ObservableCollection<Booking>();
            Guests = new ObservableCollection<Guest>();
            ViewData = new ObservableCollection<RoomsGuests>();
            HotelsRooms = new ObservableCollection<DTOHotelsRooms>();
            BookingsRooms = new ObservableCollection<DTOBookingsRooms>();
            HotelHandler.LoadHotelAsync();

        }
        #region NotifyPropertyChangedInvocator
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
