using BTBS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTBS.WebApi.Controllers
{
    public class AgentsController : ApiController
    {
        BTBSEntities entities = new BTBSEntities();
        public AgentsController()
        {
            entities.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Agent> Get()
        {
            return entities.Agents.ToList();
        }
        public IHttpActionResult Get(int id)
        {
            var agent = entities.Agents.FirstOrDefault(a=>a.Agent_Id==id);
            if (agent != null)
            {
                return Ok(agent);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post([FromBody] Agent agent)
        {
            try
            {
                entities.Agents.Add(agent);
                entities.SaveChanges();
                var message = Created("Agents", agent);
                return message;
            }
            catch (Exception ex)
            {
              return BadRequest(ex.ToString());
            }
        }
       // [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Agent agents)
        {
            try
            {
                var agent = entities.Agents.Where(a => a.Agent_Id == id).FirstOrDefault<Agent>();
                if (agent == null)
                {
                    return NotFound();
                }
                else
                {
                    agent.First_Name = agents.First_Name;
                    agent.Last_Name = agents.Last_Name;
                    agent.Email = agents.Email;
                    agent.Phone_No = agents.Phone_No;
                    agent.Password = agents.Password;
                    entities.SaveChanges();
                    return Ok(agent);
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
                var agent = entities.Agents.Where(a => a.Agent_Id == id).FirstOrDefault();
                if (agent == null)
                {
                    return NotFound();
                }
                else
                {
                    entities.Agents.Remove(agent);
                    entities.SaveChanges();
                    return Ok(agent);
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
