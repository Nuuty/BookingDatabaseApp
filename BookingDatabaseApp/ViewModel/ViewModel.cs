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
using BookingDatabaseApp.Handler;
using BookingDatabaseApp.Model;
using BookingDatabaseApp.Persistency;
using Eventmaker.Common;

namespace BookingDatabaseApp.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public HotelCatalogSingleton Catalog { get; } = HotelCatalogSingleton.Instance;
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

        private static Hotel _selectedItem;

        public Hotel SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; }
        }
        public HotelEventHandler HotelHandler { get; set; }
        private ICommand _hotelsinRoskildeCommand;

        public ICommand HotelsinRoskildeCommand
        {
            get
            {
                return _hotelsinRoskildeCommand ??
                       (_hotelsinRoskildeCommand = new RelayCommand(HotelHandler.HotelsinRoskilde));
            }
        }
        private ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(HotelHandler.DeleteHotel));
            }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new RelayCommand(HotelHandler.CreateHotel)); }
        }

        private ICommand _updateCommand;

        public ICommand UpdateCommand
        {
            get { return _updateCommand ?? (_updateCommand = new RelayCommand(HotelHandler.UpdateHotel)); }
        }
        public ViewModel()
        {
           
            HotelHandler = new HotelEventHandler(this);


        }
       

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
