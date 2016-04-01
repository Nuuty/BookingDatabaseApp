using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabaseApp.Model
{
    class BookingCatalogSingleton
    {
        private static readonly BookingCatalogSingleton _instance = new BookingCatalogSingleton();

        public static BookingCatalogSingleton Instance
        {
            get { return _instance; }
        }

        public BookingCatalogSingleton()
        {
            
        }
    }
}
