using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrafficSituationWebApp.Controllers
{
    public class AutomaticallyGeneratedMessage
    {
        public DeviceLocation Address { get; set; }
        public double Speed { get; set; }
        public string Acceleration { get; set; }
        public DateTime DateOfCreation { get; set; }


    }
    public class DeviceLocation
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public override string ToString()
        {
            return Country + ", " + City + ", " + Street;
        }
    }

    //[Authorize]
    public class ValuesController : ApiController
    {
        TrafficSituationBLL.TrafficSituationDataManager dbManager;
        const double testAcceleration = 1.5;
        public ValuesController()
        {
            dbManager = new TrafficSituationBLL.TrafficSituationDataManager();
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]AutomaticallyGeneratedMessage value)
        {
            dbManager.AddStreetsToDataBase(value.Address.Country, value.Address.City, value.Address.Street);
            dbManager.AddAutomaticallyGeneratedData(value.Address.Country, value.Address.City, value.Address.Street,
                value.Speed, testAcceleration, value.DateOfCreation);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
