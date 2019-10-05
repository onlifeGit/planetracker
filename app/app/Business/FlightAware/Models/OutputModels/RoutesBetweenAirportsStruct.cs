using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class RoutesBetweenAirportsStruct
    {
        public string aircrafttypes { set; get; }

        public int count { set; get; }

        public int filed_altitude_max { set; get; }

        public int filed_altitude_min { set; get; }

        public int last_departuretime { set; get; }

        public string route { set; get; }

        public string route_distance { set; get; }

    }
}