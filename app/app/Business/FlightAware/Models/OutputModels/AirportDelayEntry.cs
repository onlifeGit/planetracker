using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class AirportDelayEntry
    {
        public string airport { set;  get; }

        public string category { set; get; }

        public string color { set; get; }

        public int delay_secs { set; get; }

        public IEnumerable<AirportDelayReason> reasons_all { set; get; }
    }
}