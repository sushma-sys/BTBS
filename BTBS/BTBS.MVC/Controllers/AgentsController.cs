using BTBS.MVC.Models;
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
    /// All Action action methods of Agent
    /// </summary>
    public class AgentsController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AgentsController));
        public string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];

        // GET: Agents
        public ActionResult Index()
        {
            return View();
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
                logger.Error(ex.ToString());
                throw ex;
            }
        }
        //Adding Passengers
        public ActionResult AddPassenger()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPassenger(PassengerViewModel pvm)
        {
            try
            {
                logger.Info("User Logged" + pvm.Email);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var post = client.PostAsJsonAsync<PassengerViewModel>("Passengers", pvm);
                    post.Wait();
                    var result = post.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("AllPassengers");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                    return View(pvm);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }
        //Get Passengers
        [HttpGet]
        public ActionResult AllPassengers()
        {
            try
            {
                IEnumerable<PassengerViewModel> passengerList = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = client.GetAsync("Passengers");
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readResponse = result.Content.ReadAsAsync<IList<PassengerViewModel>>();
                        readResponse.Wait();
                        passengerList = readResponse.Result;
                    }
                    else
                    {
                        passengerList = Enumerable.Empty<PassengerViewModel>();
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                }
                return View(passengerList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //For ticket booking
        public ActionResult BookTicket()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BookTicket(BookingViewModel bvm)
        {
            try
            {
                logger.Info("Booking Id" + bvm.Booking_Id);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var post = client.PostAsJsonAsync<BookingViewModel>("Bookings", bvm);
                    post.Wait();
                    var result = post.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("AllAgents");
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

    }
}