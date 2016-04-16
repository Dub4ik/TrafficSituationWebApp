using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSituationDAL.Entities
{
    public class TrafficSituationReport:Entity 
    {
        public byte TrafficLevel { get; set; }
        public DateTime DataOfGeneration { get; set; }
        public int Streetid { get; set; }
        public Street Street { get; set; }
    }   
}
