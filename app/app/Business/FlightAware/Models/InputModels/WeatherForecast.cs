using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class WeatherForecast
    {
        public string airport_code { set; get; }

        public int? weather_date { set; get; }

        public bool? return_nearby_weather { set; get; }
    }
}