using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class CountAirportOperationsResult
    {
        public int departed { set; get; }

        public int enroute { set; get; }

        public int scheduled_arrivals { set; get; }

        public int scheduled_departures { set; get; }
    }
}