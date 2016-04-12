using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BookingWebservice;
using BookingWebservice.Models;

namespace BookingWebservice.Controllers
{
    public class HotelsController : ApiController
    {
        private HotelCloudContext db = new HotelCloudContext();

        // GET: api/Hotels
        public IQueryable<Hotel> GetHotel()
        {
            return db.Hotel;
        }

        // GET: api/Hotels/5
        [ResponseType(typeof(Hotel))]
        public IHttpActionResult GetHotel(int id)
        {
            Hotel hotel = db.Hotel.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        // PUT: api/Hotels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHotel(int id, Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotel.Hotel_No)
            {
                return BadRequest();
            }

            db.Entry(hotel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Hotels
        [ResponseType(typeof(Hotel))]
        public IHttpActionResult PostHotel(Hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hotel.Add(hotel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HotelExists(hotel.Hotel_No))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hotel.Hotel_No }, hotel);
        }

        // DELETE: api/Hotels/5
        [ResponseType(typeof(Hotel))]
        public IHttpActionResult DeleteHotel(int id)
        {
            Hotel hotel = db.Hotel.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }

            db.Hotel.Remove(hotel);
            db.SaveChanges();

            return Ok(hotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HotelExists(int id)
        {
            return db.Hotel.Count(e => e.Hotel_No == id) > 0;
        }
    }
}