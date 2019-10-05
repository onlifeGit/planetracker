using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class FindFlightResult
    {
        public FindFlightMatch flights { set; get; }

        public int next_offset { set; get; }

        public int num_flights { set; get; }
    }
}