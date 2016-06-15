using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrafficSituationBLL;

namespace TrafficSituationWebApp.Controllers
{
    public class RequestParams
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public DateTime Date { get; set; }
        public string TypeRequest { get; set; }
    }
    public class ArchivesController : ApiController
    {
        TrafficSituationDataManager dataManager = new TrafficSituationDataManager();
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public IEnumerable<TrafficData> Get([FromUri]RequestParams parameters)
        {
            //TODO переделать
            try
            {
                if (parameters.TypeRequest=="PerCurrentTime")
                {
                    return dataManager.GetTrafficDataForExactTime(parameters.Country, parameters.City, parameters.Street, parameters.Date);
                }
                else
                {
                    return dataManager.GetTrafficDataPerHour(parameters.Country, parameters.City, parameters.Street, parameters.Date);
                }
                
            }
                catch (Exception e)
            {
                //TODO найти правильную реализацию 
                //throw;
                return new List<TrafficData>();
            }
        }
    }
}
