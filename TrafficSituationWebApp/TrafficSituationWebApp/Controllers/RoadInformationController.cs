using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrafficSituationBLL;

namespace TrafficSituationWebApp.Controllers
{
    public class RoadInformationController : ApiController
    {
        TrafficSituationDataManager dataManager = new TrafficSituationDataManager();
        public IEnumerable<RoadInformation> Get()
        {
            return dataManager.GetActualRoadInformation();
        }
    }
}
