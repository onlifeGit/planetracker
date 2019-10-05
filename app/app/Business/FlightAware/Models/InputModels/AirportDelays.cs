using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class AirportDelays
    {
        public string airport_code { set; get; }

        public Nullable<int> howMany { set; get; }

        public Nullable<int> offset { set; get; }
    }
}