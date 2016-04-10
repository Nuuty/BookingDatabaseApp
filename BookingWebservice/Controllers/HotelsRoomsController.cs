using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookingWebservice;
using BookingWebservice.Models;

namespace BookingWebservice.Controllers
{
    [RoutePrefix("api/AllRooms")]
    public class HotelsRoomsController : ApiController
    {
        private HotelContext db = new HotelContext();

        [Route("{name}")]
        [ResponseType(typeof(HotelsRooms))]
        // GET: api/HotelsRooms
        public IQueryable<HotelsRooms> GetHotelsRooms(string name)
        {
            var query = from hotel in db.Hotel
                join room in db.Room on hotel.Hotel_No equals room.Hotel_No
                        where hotel.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                select
                    new HotelsRooms()
                    {
                        Address = hotel.Address,
                        Hotel_No = hotel.Hotel_No,
                        Name = hotel.Name,
                        Price = room.Price,
                        Room_No = room.Room_No,
                        Types = room.Types
                    };
            return query;


        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}