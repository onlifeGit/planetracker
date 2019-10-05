using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class AirportDelaysResult
    {
        public IEnumerable<AirportDelayEntry> delays { set; get; }

        public int next_offset { set; get; }
    }
}