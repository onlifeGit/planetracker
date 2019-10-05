using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class AirlineInfoResult
    {
        public int? airbourne { set; get; }

        public string callsign { set; get; }

        public string country { set; get; }

        public int? flights_last_24_hours { set; get; }

        public string location { set; get; }

        public string name { set; get; }

        public string phone { set; get; }

        public string shortname { set; get; }

        public string url { set; get; }

        public string wiki_url { set; get; }
    }
}