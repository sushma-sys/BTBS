using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTBS.MVC.Controllers
{

    public class HomeController : Controller
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            logger.Info("Opend Home Page");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}