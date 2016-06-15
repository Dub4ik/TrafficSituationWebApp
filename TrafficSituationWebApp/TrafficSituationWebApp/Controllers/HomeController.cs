using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrafficSituationWebApp.Controllers
{

    public class HomeController : Controller
    {
        TrafficSituationBLL.TrafficSituationDataManager dataManager;
        public ActionResult Index()
        {


            //dataManager = new TrafficSituationBLL.TrafficSituationDataManager();
            //dataManager.GenerateTestData();
            ViewBag.Title = "Home Page ";
            return View();
        }
    }
}
