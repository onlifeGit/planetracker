using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class AirportStruct
    {
        public string airport_code { set; get; }

        public string city { set; get; }

        public string country_code { set; get; }

        public string direction { set; get; }

        public int? distance { set; get; }

        public float? elevation { set; get; }

        public int? heading { set; get; }

        public float latitude { set; get; }

        public float longitude { set; get; }

        public string name { set; get; }

        public string state { set; get; }

        public string timezone { set; get; }

        public string wiki_url { set; get; }
    }
}