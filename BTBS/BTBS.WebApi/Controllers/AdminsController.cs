using BTBS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTBS.WebApi.Controllers
{
    public class AdminsController : ApiController
    {
        BTBSEntities entities = new BTBSEntities();
        public AdminsController()
        {
            entities.Configuration.ProxyCreationEnabled = false;
        }
        public IEnumerable<Admin> Get()
        {
            return entities.Admins.ToList();
        }
        public IHttpActionResult Get(int id)
        {
            var admin = entities.Admins.FirstOrDefault(a => a.Admin_Id == id);
            if (admin != null)
            {
                return Ok(admin);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post([FromBody] Admin admin)
        {
            try
            {
                entities.Admins.Add(admin);
                entities.SaveChanges();
                var message = Created("Admins", admin);
                return message;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        public IHttpActionResult Put(int id, [FromBody] Admin admins)
        {
            try
            {
                var admin = entities.Admins.FirstOrDefault(a => a.Admin_Id == id);
                if (admin == null)
                {
                    return NotFound();
                }
                else
                {
                    admin.First_Name = admins.First_Name;
                    admin.Last_Name = admins.Last_Name;
                    admin.Email = admins.Email;
                    admin.Phone_No = admins.Phone_No;
                    admin.Password = admins.Password;
                    entities.SaveChanges();
                    return Ok(admin);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        //[HttpDelete]
        //[Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var admin = entities.Admins.FirstOrDefault(a => a.Admin_Id == id);
                if (admin == null)
                {
                    return NotFound();
                }
                else
                {
                    entities.Admins.Remove(admin);
                    entities.SaveChanges();
                    return Ok(admin);
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
