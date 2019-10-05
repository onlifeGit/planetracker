using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class FindFlightMatch
    {
        public int num_segments { set; get; }

        public FlightInfoStatusStruct segments { set; get; }
    }
}