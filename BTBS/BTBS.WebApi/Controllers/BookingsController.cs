using BTBS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTBS.WebApi.Controllers
{
    public class BookingsController : ApiController
    {
       BTBSEntities entities = new BTBSEntities();
        public BookingsController()
        {
            entities.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Booking> Get()
        {
            return entities.Bookings.ToList();
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
           // BTBSEntities bk = new BTBSEntities();
            var booking = entities.Bookings.Where(b => b.Passenger_Id.Value == id).ToList();
            if (booking != null)
            {
                return Ok(booking);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post([FromBody] Booking booking)
        {
            try
            {
                entities.Bookings.Add(booking);
                entities.SaveChanges();
                var message = Created("Bookings", booking);
                return message;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                entities.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
