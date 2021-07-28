using BTBS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using BTBS.WebApi.Models;
using System.Web.Http.Description;

namespace BTBS.WebApi.Controllers
{
    public class BusesController : ApiController
    {
        BTBSEntities entities = new BTBSEntities();
        public BusesController()
        {
            entities.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Bus> Get()
        {
            return entities.Buses.ToList();
        }
        public IHttpActionResult Get(int id)
        {
            var bus = entities.Buses.FirstOrDefault(b => b.Bus_No == id);
            if (bus != null)
            {
                return Ok(bus);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post([FromBody] Bus bus)
        {
            try
            {
                entities.Buses.Add(bus);
                entities.SaveChanges();
                var message = Created("Buses", bus);
                return message;
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        // [Route("api/BusesPut/{id}")]
        public IHttpActionResult Put(int id, [FromBody] Bus buses)
        {
            try
            {
                var bus = entities.Buses.FirstOrDefault(b => b.Bus_No == id);
                if (bus == null)
                {
                    return NotFound();
                }
                else
                {
                    bus.Starting_City = buses.Starting_City;
                    bus.Destination = buses.Destination;
                    bus.Bus_type = buses.Bus_type;
                    bus.Child_cost = buses.Child_cost;
                    bus.Adult_Cost = buses.Adult_Cost;
                    bus.Broarding_Point = buses.Broarding_Point;
                    bus.Broarding_Duration = buses.Broarding_Duration;
                    bus.Arrival_At_Broarding = buses.Arrival_At_Broarding;
                    bus.Departure_Time = buses.Departure_Time;
                    bus.Capacity = buses.Capacity;
                    entities.SaveChanges();
                    return Ok(bus);

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var bus = entities.Buses.Where(b => b.Bus_No == id).FirstOrDefault();
                if (bus == null)
                {
                    return NotFound();
                }
                else
                {
                    entities.Buses.Remove(bus);
                    entities.SaveChanges();
                    return Ok(bus);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]
        public IHttpActionResult SearchBus(string from,string to)
        {
            var bus = entities.Buses.Where(b => b.Starting_City == from && b.Destination == to).ToList();
            if (bus != null)
            {
                return Ok(bus);
            }
            else
            {
                return NotFound();
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
