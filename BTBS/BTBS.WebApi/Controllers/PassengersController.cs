using BTBS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BTBS.WebApi.Controllers
{
    public class PassengersController : ApiController
    {
        BTBSEntities entities = new BTBSEntities();
        public PassengersController()
        {
            entities.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Passenger> Get()
        {
            return entities.Passengers.ToList();
        }
        public IHttpActionResult Get(int id)
        {
            var passenger = entities.Passengers.FirstOrDefault(p => p.Passenger_Id == id);
            if (passenger != null)
            {
                return Ok(passenger);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post([FromBody] Passenger passenger)
        {
            try
            {
                entities.Passengers.Add(passenger);
                entities.SaveChanges();
                var message = Created("Passengers", passenger);
                return message;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, [FromBody] Passenger passengers)
        {
            try
            {
                var passenger = entities.Passengers.FirstOrDefault(p => p.Passenger_Id == id);
                if (passenger == null)
                {
                    return NotFound();
                }
                else
                {
                    passenger.First_Name = passengers.First_Name;
                    passenger.Last_Name = passengers.Last_Name;
                    passenger.Age = passengers.Age;
                    passenger.Gender = passengers.Gender; ;
                    passenger.Email = passengers.Email;
                    passenger.Phone_No = passengers.Phone_No;
                    passenger.Password = passengers.Password;
                    entities.SaveChanges();
                    return Ok(passenger);
                }
                // entities.Entry(passenger).State= EntityState.Modified;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        //[HttpDelete]
        //[Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var passenger = entities.Passengers.FirstOrDefault(p => p.Passenger_Id == id);
                if (passenger == null)
                {
                    return NotFound();
                }
                else
                {
                    entities.Passengers.Remove(passenger);
                    entities.SaveChanges();
                    return Ok(passenger);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
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

