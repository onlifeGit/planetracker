using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class WeatherConditionsStruct
    {
        public string airport_code { set; get; }

        public string cloud_friendly { set; get; }

        public string clouds { set; get; }

        public string conditions { set; get; }

        public float pressure { set; get; }

        public string pressure_units { set; get; }

        public string raw_data { set; get; }

        public int temp_air { set; get; }

        public int temp_dewpoint { set; get; }

        public string temp_perceived { set; get; }

        public int temp_relhum { set;get; }

        public int time { set; get; }

        public float visibility { set; get; }

        public string visibility_units { set; get; }

        public int wind_direction { set; get; }

        public string wind_friendly { set; get; }

        public int wind_speed { set; get; }

        public int wind_speed_gust { set; get; }

        public string wind_units { set; get; }
    }
}