using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class Timestamp
    {
        public int epoch { get; set; }
        public string tz { get; set; }
        public string dow { get; set; }
        public string time { get; set; }
        public string date { get; set; }
        public int localtime { get; set; }
    }
}