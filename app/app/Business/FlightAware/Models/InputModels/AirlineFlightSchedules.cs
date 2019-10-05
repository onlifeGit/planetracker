using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class AirlineFlightSchedules
    {
        public int start_date { set; get; }

        public int end_date { set; get; }

        public string origin { set; get; }

        public string destination { set; get; }

        public string airline { set; get; }

        public string flightno { set; get; }

        public Nullable<bool> exclude_codeshare { set; get; }

        public Nullable<int> howMany { set; get; }

        public Nullable<int> offset { set; get; }
    }
}