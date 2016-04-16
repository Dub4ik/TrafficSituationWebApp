using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSituationDAL.Entities
{
    public class ManuallyGeneratedData:Entity
    {
        public byte TrafficLevel { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int StreetId { get; set; }
        public Street Street { get; set; }
    }
}
