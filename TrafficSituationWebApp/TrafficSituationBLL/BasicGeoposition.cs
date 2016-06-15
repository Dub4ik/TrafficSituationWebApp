using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSituationBLL
{
    public struct BasicGeoposition
    {
        //
        // Summary:
        //     The altitude of the geographic position.
        public System.Double Altitude;
        //
        // Summary:
        //     The latitude of the geographic position. The valid range of latitude values is
        //     from -90.0 to 90.0 degrees.
        public System.Double Latitude;
        //
        // Summary:
        //     The longitude of the geographic position. This can be any value. For values less
        //     than or equal to-180.0 or values greater than 180.0, the value may be wrapped
        //     and stored appropriately before it is used. For example, a longitude of 183.0
        //     degrees would become -177.0 degrees.
        public System.Double Longitude;
    }
}
