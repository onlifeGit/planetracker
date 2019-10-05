using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class GetFlightTrack
    {
        public string ident { set; get; }

        public bool? include_position_estimates { set; get; }
    }
}