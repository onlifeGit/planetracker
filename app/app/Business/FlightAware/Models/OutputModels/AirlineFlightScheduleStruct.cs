using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class AirlineFlightScheduleStruct
    {
        public string actual_ident { set; get; }

        public string aircrafttype { set; get; }

        public int arrivaltime { set; get; }

        public int departuretime { set; get; }

        public string destination { set; get; }

        public string fa_ident { set; get; }

        public string ident { set; get; }

        public string meal_service { set; get; }

        public string origin { set; get; }

        public int? seats_cabin_business { set; get; }

        public int? seats_cabin_coach { set; get; }

        public int? seats_cabin_first { set; get; }

    }
}