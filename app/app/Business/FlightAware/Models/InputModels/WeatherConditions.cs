using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class WeatherConditions
    {
        public string airport_code { set; get; }

        public int? weather_date { set; get; }

        public string temperature_units { set; get; }

        public bool return_nearby_weather { set; get; }

        public int? howMany { set; get; }

        public int? offset { set; get; }
    }
}