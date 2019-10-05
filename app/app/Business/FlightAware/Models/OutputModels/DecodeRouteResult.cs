using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class DecodeRouteResult
    {
        public IEnumerable<FlightRouteStruct> data { set; get; }

        public string route_distance { set; get; }
    }
}