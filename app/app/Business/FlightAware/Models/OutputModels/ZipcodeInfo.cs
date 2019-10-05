using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class ZipcodeInfo
    {
        public string city { set; get; }

        public string country { set; get; }

        public float latitude { set; get; }

        public float longitude { set; get; }

        public string state { set; get; }
    }
}