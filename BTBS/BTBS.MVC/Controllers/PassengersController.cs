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
    /// All Action methods of Passenger
    /// </summary>
    public class PassengersController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PassengersController));
        public string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        // GET: Passengers
        public ActionResult Index()
        {
            return View();
        }
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
        //To see booked ticket
        [HttpGet]
        public ActionResult ViewTickets(int? id)
        {
            try
            {
                logger.Info("Searching Id" + id);
                IEnumerable<BookingViewModel> ticketList = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    var response = client.GetAsync("Bookings?id=" + id);
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readResponse = result.Content.ReadAsAsync<IList<BookingViewModel>>();
                        readResponse.Wait();
                        ticketList = readResponse.Result;
                    }
                    else
                    {
                        ticketList = Enumerable.Empty<BookingViewModel>();
                        ModelState.AddModelError(string.Empty, " A Error Occured ");
                    }
                }

                return View(ticketList);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }
        }
        public ActionResult SearchBus()
        {
           List <BusViewModel> bs = new List<BusViewModel>();
            return View(bs);
        }
        [HttpPost]
        public ActionResult SearchBus(string from,string to)
        {
            try
            {
                logger.Info("Search with From:" + from + "And To:" + to);
                IEnumerable<BusViewModel> busList = null;
                //av.Where(x => x.Starting_City == from && x.Destination == to).FirstOrDefault();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    // var response = client.GetAsync("Buses?from"+from ,"Buses?to"+to);
                    var response = client.GetAsync(string.Format("Buses/SearchBus?from={0}&to={1}", from, to));
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
                logger.Error(ex.ToString());
                throw ex;
            }
        }

    }
}