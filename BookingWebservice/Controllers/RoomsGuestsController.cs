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

namespace BookingWebservice.Controllers
{
    public class RoomsGuestsController : ApiController
    {
        private HotelGuestsContext db = new HotelGuestsContext();

        // GET: api/RoomsGuests
        public IQueryable<RoomsGuests> GetRoomsGuests()
        {
            return db.RoomsGuests;
        }

        // GET: api/RoomsGuests/5
        [ResponseType(typeof(RoomsGuests))]
        public IHttpActionResult GetRoomsGuests(string id)
        {
            RoomsGuests roomsGuests = db.RoomsGuests.Find(id);
            if (roomsGuests == null)
            {
                return NotFound();
            }

            return Ok(roomsGuests);
        }

        // PUT: api/RoomsGuests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoomsGuests(string id, RoomsGuests roomsGuests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomsGuests.Hnavn)
            {
                return BadRequest();
            }

            db.Entry(roomsGuests).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomsGuestsExists(id))
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

        // POST: api/RoomsGuests
        [ResponseType(typeof(RoomsGuests))]
        public IHttpActionResult PostRoomsGuests(RoomsGuests roomsGuests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoomsGuests.Add(roomsGuests);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RoomsGuestsExists(roomsGuests.Hnavn))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = roomsGuests.Hnavn }, roomsGuests);
        }

        // DELETE: api/RoomsGuests/5
        [ResponseType(typeof(RoomsGuests))]
        public IHttpActionResult DeleteRoomsGuests(string id)
        {
            RoomsGuests roomsGuests = db.RoomsGuests.Find(id);
            if (roomsGuests == null)
            {
                return NotFound();
            }

            db.RoomsGuests.Remove(roomsGuests);
            db.SaveChanges();

            return Ok(roomsGuests);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoomsGuestsExists(string id)
        {
            return db.RoomsGuests.Count(e => e.Hnavn == id) > 0;
        }
    }
}