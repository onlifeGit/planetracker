using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class LatLongsToDistance
    {
        public float lat1 { set; get; }

        public float lon1 { set; get; }

        public float lat2 { set; get; }

        public float lon2 { set; get; }
    }
}