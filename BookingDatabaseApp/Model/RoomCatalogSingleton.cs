using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDatabaseApp.Model
{
    class RoomCatalogSingleton
    {
        private static readonly RoomCatalogSingleton _instance = new RoomCatalogSingleton();

        public static RoomCatalogSingleton Instance
        {
            get { return _instance; }
        }

        public RoomCatalogSingleton()
        {
            
        }
    }
}
