using BTBS.MVC.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BTBS.MVC.Controllers
{
    [Authorize]
    /// <summary>
    /// All action methods of Admin
    /// </summary>
    public class AdminsController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AdminsController));
        public string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllAdmins()
        {
            try
            {
                IEnumerable<AdminViewModel> adminList = null;
                // string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = client.GetAsync("Admins");
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readResponse = result.Content.ReadAsAsync<IList<AdminViewModel>>();
                        readResponse.Wait();
                        adminList = readResponse.Result;
                    }
                    else
                    {
                        adminList = Enumerable.Empty<AdminViewModel>();
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                }
                return View(adminList);

            }
            catch (Exception ex)
            {

                throw ex;
            }        
        }
        public ActionResult AdminDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminDetails(AdminViewModel avm)
        {
            string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                var post = client.PostAsJsonAsync<AdminViewModel>("Admins", avm);
                post.Wait();
                var result = post.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("AllAdmins");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, " A Error Occured ");
                }
                return View(avm);
            }
        }
        public ActionResult AllAgents()
        {
            try
            {
                IEnumerable<AgentViewModel> agentList = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = client.GetAsync("Agents");
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readResponse = result.Content.ReadAsAsync<IList<AgentViewModel>>();
                        readResponse.Wait();
                        agentList = readResponse.Result;
                    }
                    else
                    {
                        agentList = Enumerable.Empty<AgentViewModel>();
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                }
                return View(agentList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult AllBuses()
        {
            try
            {
                IEnumerable<BusViewModel> busList = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = client.GetAsync("Buses");
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readResponse = result.Content.ReadAsAsync<IList<BusViewModel>>();
                        readResponse.Wait();
                        busList = readResponse.Result;
                    }
                    else
                    {
                        busList = Enumerable.Empty<BusViewModel>();
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                }
                return View(busList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult AllRoutes()
        {
            try
            {
                IEnumerable<RouteViewModel> routeList = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = client.GetAsync("Routes");
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readResponse = result.Content.ReadAsAsync<IList<RouteViewModel>>();
                        readResponse.Wait();
                        routeList = readResponse.Result;
                    }
                    else
                    {
                        routeList = Enumerable.Empty<RouteViewModel>();
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                }
                return View(routeList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ActionResult AddAgent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAgent(AgentViewModel agvm)
        {
            try
            {
                string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var post = client.PostAsJsonAsync<AgentViewModel>("Agents", agvm);
                    post.Wait();
                    var result = post.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        logger.Info("Successfully Add New AGENT:" + agvm.Email);
                        return RedirectToAction("AllAgents");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                    return View(agvm);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }
        public ActionResult AddBus()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBus(BusViewModel bvm)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var post = client.PostAsJsonAsync<BusViewModel>("Buses", bvm);
                    post.Wait();
                    var result = post.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        logger.Info("Successfully Add New BUS:" + bvm.Bus_No);
                        return RedirectToAction("AllBuses");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                    return View(bvm);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());

                throw ex;
            }
        }
        public ActionResult AddRoute()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddRoute(RouteViewModel rvm)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var post = client.PostAsJsonAsync<RouteViewModel>("Routes", rvm);
                    post.Wait();
                    var result = post.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        logger.Info("Successfully Add new ROUTE:" + rvm.Route_Name);
                        return RedirectToAction("AllRoutes");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                    return View(rvm);
                }
            }
            catch (Exception ex)
            { 
                logger.Error(ex.ToString());

                throw ex;
            }
        }
        [MvcSiteMapNode(Title = "EditAgent", ParentKey = "Agents")]
        public ActionResult EditAgent(int id)
        {
            try
            {
                AgentViewModel agvm = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = client.GetAsync("Agents?id=" + id);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readResponse = result.Content.ReadAsAsync<AgentViewModel>();
                        readResponse.Wait();
                        agvm = readResponse.Result;
                    }
                    else
                    {
                        // agvm = E.Empty<AgentViewModel>();
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                }
                return View(agvm);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());

                throw ex;
            }

        }
        [HttpPost]
        public ActionResult EditAgent(int id, AgentViewModel agvm)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var put = client.PutAsJsonAsync<AgentViewModel>("Agents?id=" + id, agvm);
                    put.Wait();
                    var result = put.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        logger.Info("Successfully Edited Agent" + id);
                        return RedirectToAction("AllAgents");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                    return View(agvm);

                }
            }
            catch (Exception ex)
            { 
              logger.Error(ex.ToString());

                throw ex;
            }
        }
        public ActionResult EditBus(int id)
        {
            try
            {
                BusViewModel bvm = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = client.GetAsync("Buses?id=" + id);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readResponse = result.Content.ReadAsAsync<BusViewModel>();
                        readResponse.Wait();
                        bvm = readResponse.Result;
                    }
                    else
                    {
                        // agvm = E.Empty<AgentViewModel>();
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                }
                return View(bvm);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());

                throw ex;
            }
        }
        [HttpPost]
        public ActionResult EditBus(int id, BusViewModel bvm)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var put = client.PutAsJsonAsync<BusViewModel>("Buses?id=" + id, bvm);
                    put.Wait();
                    var result = put.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        logger.Info("Successfully Edited Bus" + id);
                        return RedirectToAction("AllBuses");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                    return View(bvm);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());

                throw ex;
            }
        }
        public ActionResult EditRoute(int id)
        {
            try
            {
                logger.Info("Edited ID:" + id);
                RouteViewModel rvm = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = client.GetAsync("Routes?id=" + id);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readResponse = result.Content.ReadAsAsync<RouteViewModel>();
                        readResponse.Wait();
                        rvm = readResponse.Result;
                    }
                    else
                    {
                        // agvm = E.Empty<AgentViewModel>();
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                    return View(rvm);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());

                throw ex;
            }
        }
        [HttpPost]
        public ActionResult EditRoute(int id, RouteViewModel rvm)
        {
            try
            {
                logger.Info("Edited ID:" + id);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var put = client.PutAsJsonAsync<RouteViewModel>("Routes?id=" + id, rvm);
                    put.Wait();
                    var result = put.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        logger.Info("Successfully Edited Route" + id);
                        return RedirectToAction("AllRoutes");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                   // logger.Info("Saved Edited Route" + id);
                    return View(rvm);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());

                throw ex;
            }
        }
        public ActionResult DeleteAgent(int id)
        {
            try
            {
                AgentViewModel agvm = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = client.GetAsync("Agents?id=" + id);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readResponse = result.Content.ReadAsAsync<AgentViewModel>();
                        readResponse.Wait();
                        agvm = readResponse.Result;
                    }
                    else
                    {
                        // agvm = E.Empty<AgentViewModel>();
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                }
                return View(agvm);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());

                throw ex;
            }
        }
        [HttpPost]
        public ActionResult DeleteAgent(int id, AgentViewModel agvm)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var put = client.DeleteAsync("Agents?id=" + id);
                    put.Wait();
                    var result = put.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        logger.Info("Successfully deleted Agent" + id);
                        return RedirectToAction("AllAgents");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                    return View(agvm);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());

                throw ex;
            }
        }
        public ActionResult DeleteBus(int id)
        {
            try
            {
                BusViewModel bvm = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = client.GetAsync("Buses?id=" + id);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readResponse = result.Content.ReadAsAsync<BusViewModel>();
                        readResponse.Wait();
                        bvm = readResponse.Result;
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                }
                return View(bvm);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());

                throw ex;
            }
        }
        [HttpPost]
        public ActionResult DeleteBus(int id, BusViewModel bvm)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var put = client.DeleteAsync("Buses?id=" + id);
                    put.Wait();
                    var result = put.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        logger.Info("Successfully Deleted Bus" + id);
                        return RedirectToAction("AllBuses");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                    return View(bvm);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());

                throw ex;
            }
        }
        public ActionResult DeleteRoute(int id)
        {
            try
            {
                logger.Info("Edited ID:" + id);
                RouteViewModel rvm = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = client.GetAsync("Routes?id=" + id);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readResponse = result.Content.ReadAsAsync<RouteViewModel>();
                        readResponse.Wait();
                        rvm = readResponse.Result;
                    }
                    else
                    {
                        // agvm = E.Empty<AgentViewModel>();
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                    return View(rvm);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());

                throw ex;
            }
        }
        [HttpPost]
        public ActionResult DeleteRoute(int id, RouteViewModel rvm)
        {
            try
            {
                logger.Info("Edited ID:" + id);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var put = client.PutAsJsonAsync<RouteViewModel>("Routes?id=" + id, rvm);
                    put.Wait();
                    var result = put.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        logger.Info("Successfully Edited Route" + id);
                        return RedirectToAction("AllRoutes");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                    // logger.Info("Saved Edited Route" + id);
                    return View(rvm);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());

                throw ex;
            }
        }

    }
}