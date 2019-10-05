using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class RoutesBetweenAirportsResult
    {
        public IEnumerable<RoutesBetweenAirportsStruct> data { set; get; }

        public int next_offset { set; get; }
    }
}