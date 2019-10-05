using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class GetFlightTrackResult
    {
        public IEnumerable<TrackStruct> tracks { set; get; }
    }
}