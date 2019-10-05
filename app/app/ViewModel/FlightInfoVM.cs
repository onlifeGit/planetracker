using app.Business.FlightAware.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.ViewModel
{
    public class FlightInfoVM
    {
        public string FlightId { set; get; }

        public float Latitude { set; get; }

        public float Longitude { set; get; }

        //public AirlineModel Airline { set; get; }

        public string Airline { set; get; }
    }
}