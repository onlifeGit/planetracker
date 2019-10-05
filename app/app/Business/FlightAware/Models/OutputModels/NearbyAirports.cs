using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class NearbyAirports
    {
        public AirportStruct airports { set; get; }

        public int next_offset { set; get; }
    }
}