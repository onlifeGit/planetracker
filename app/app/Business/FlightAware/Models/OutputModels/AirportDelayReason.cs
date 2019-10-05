using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class AirportDelayReason
    {
        public string category { set; get; }

        public string color { set; get; }

        public int delay_secs { set; get; }

        public string reason { set; get; }
    }
}