using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class FlightCancellationStatistics
    {
        public string time_period { set; get; }

        public string type_matching { set; get; }

        public string ident_filter { set; get; }

        public int? howMany { set; get; }

        public int? offset { set; get; }
    }
}