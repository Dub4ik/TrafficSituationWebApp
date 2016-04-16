using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSituationDAL.Entities
{
    public class Street:Entity
    {
        public string Name { get; set; }
        public string Geolocation { get; set; }
        public int CityId { get; set; }
        public List<Accident> Accidents { get; set; }
        public List<ManuallyGeneratedData> ManuallyGeneratedDataList { get; set; }
        public List<AutomaticallyGeneratedData> AutomaticallyGeneratedDataList { get; set; }
        public List<TrafficSituationReport> TrafficSituationReports{ get; set; }    
    }
}
