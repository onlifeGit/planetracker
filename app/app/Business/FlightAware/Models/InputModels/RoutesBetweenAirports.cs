using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class RoutesBetweenAirports
    {
        public string origin { set; get; }

        public string destination { set; get; }

        public string max_file_age { set; get; }

        public string sort_by { set; get; }

        public int? howMany { set; get; }

        public int? offset { set; get; }
    }
}