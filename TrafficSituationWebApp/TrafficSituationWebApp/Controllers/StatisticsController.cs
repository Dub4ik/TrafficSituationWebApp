using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TrafficSituationBLL;

namespace TrafficSituationWebApp.Controllers
{
    //public class RequestParams
    //{
    //    public string Country { get; set; }
    //    public string City { get; set; }
    //    public string Street { get; set; }
    //    public DateTime Date { get; set; }
    //    public string TypeRequest { get; set; }
    //}
    public class StatisticsController : Controller
    {
        public TrafficSituationDataManager dataManager = new TrafficSituationDataManager();
        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

         public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public IEnumerable<TrafficData> Get([FromUri]RequestParams parameters)
        {
            //TODO переделать
            return dataManager.GetTrafficDataForExactTime(parameters.Country, parameters.City, parameters.Street, parameters.Date);

        }
    }
}