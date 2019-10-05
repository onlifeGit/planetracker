using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class TrackStruct
    {
        public int altitude { set; get; }

        public string altitude_change { set; get; }

        public string altitude_status { set; get; }

        public int groundspeed { set; get; }

        public float latitude { set; get; }

        public float longitude { set; get; }

        public int timestamp { set; get; }

        public string update_type { set; get; }
    }
}