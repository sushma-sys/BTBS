using BTBS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTBS.WebApi.Controllers
{
    public class RoutesController : ApiController
    {
        BTBSEntities entities = new BTBSEntities();
        public RoutesController()
        {
            entities.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Route> Get()
        {
           return entities.Routes.ToList();
        }
        public IHttpActionResult Get(int id)
        {
            var route = entities.Routes.FirstOrDefault(r => r.Route_No == id);
            if (route != null)
            {
                return Ok(route);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post([FromBody]Route route)
        {
            try
            {
                entities.Routes.Add(route);
                entities.SaveChanges();
                var message = Created("Routes", route);
                return message;
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        public IHttpActionResult Put(int id, [FromBody] Route routes)
        {
            var route = entities.Routes.FirstOrDefault(r => r.Route_No == id);
            if (route == null)
            {
                return NotFound();
            }
            else
            {
                route.Route_Name = routes.Route_Name;
                route.Stops = routes.Stops;
                route.Stage_Cost = routes.Stage_Cost;
                route.Start_Stage = routes.Start_Stage;
                route.End_Stage = routes.End_Stage;
                route.Start_time = routes.Start_time;
                route.End_time = routes.End_time;
                return Ok(route);
            }
        }
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var route = entities.Routes.Where(r=>r.Route_No == id).FirstOrDefault();
                if (route == null)
                {
                    return NotFound();
                }
                else
                {
                    entities.Routes.Remove(route);
                    entities.SaveChanges();
                    return Ok(route);
                }
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
