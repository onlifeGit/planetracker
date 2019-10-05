using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class NearbyAirports
    {
        public float? latitude { set; get; }

        public float? longitude { set; get; }

        public string airport_code { set; get; }

        public int radius { set; get; }

        public bool only_iap { set; get; }

        public int? howMany { set; get; }

        public int? offset { set; get; }
    }
}