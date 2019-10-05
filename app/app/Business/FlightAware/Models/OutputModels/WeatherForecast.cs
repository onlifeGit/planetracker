using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class WeatherForecast
    {
        public string airport_code { set; get; }

        public string decoded_forecast { set; get; }

        public string raw_forecast { set; get; }

        public string timestring { set; get; }
    }
}