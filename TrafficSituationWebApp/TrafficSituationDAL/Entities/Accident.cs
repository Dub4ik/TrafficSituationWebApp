using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSituationDAL.Entities
{
    public class Accident:Entity
    {
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int Confirmed { get; set; }      
        public int NotConfirmed { get; set; }
        public int StreetId { get; set; }
        public Street Street { get; set; }
    }
}
