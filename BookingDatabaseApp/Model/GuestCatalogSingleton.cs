using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabaseApp.Model
{
    class GuestCatalogSingleton
    {
        private static readonly GuestCatalogSingleton _instance = new GuestCatalogSingleton();

        public static GuestCatalogSingleton Instance
        {
            get { return _instance; }
        }

        public GuestCatalogSingleton()
        {
            
        }
    }
}
