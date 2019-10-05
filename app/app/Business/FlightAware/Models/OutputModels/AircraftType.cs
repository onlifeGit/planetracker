using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class AircraftType
    {
        public string description { get; set;}

        public int? engine_count { get; set;}

        public string engine_type { get; set;}

        public string manufacturer { get; set;}

        public string type { get; set;}
    }
}