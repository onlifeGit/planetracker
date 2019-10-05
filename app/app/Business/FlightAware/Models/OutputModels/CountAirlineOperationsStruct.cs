using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class CountAirlineOperationsStruct
    {
        public int enroute { set; get; }

        public string icao { set; get; }

        public string name { set; get; }
    }
}