using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class FlightRouteStruct
    {
        public Nullable<float> distance_from_origin { set; get; }

        public Nullable<float> distance_this_leg { set; get; }

        public Nullable<float> distance_to_destination { set; get; }

        public Nullable<float> latitude { set; get; }

        public Nullable<float> longitude { set; get; }

        public string name { set; get; }

        public Nullable<float> outbound_course { set; get; }

        public string type { set; get; }
    }
}