using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class FlightInfoStatusStruct
    {
        public Timestamp actual_arrival_time { set; get; }

        public Timestamp actual_blockin_time { set; get; }

        public Timestamp actual_blockout_time { set; get; }

        public Timestamp actual_departure_time { set; get; }

        public bool adhoc { set; get; }

        public string aircrafttype { set; get; }
        
        public string airline { set; get; }

        public int? arrival_delay { set; get; }

        public string bag_claim { set; get; }

        public bool blocked { set; get; }

        public bool cancelled { set; get; }

        public string codeshares { set; get; }

        public bool? datalink { set; get; }

        public int? departure_delay { set; get; }

        public AirportInfoResult destination { set; get; }

        public string dispaly_aircraft { set; get; }

        public string display_filed_altitude { set; get; }

        public int? distance_filed { set; get; }

        public bool diverted { set; get; }

        public Timestamp estimated_arrival_time { set; get; }

        public Timestamp estimated_blockin_time { set; get; }

        public Timestamp estimated_blockout_time { set; get; }

        public Timestamp estimated_departure_time { set; get; }

        public string faFlightID { set; get; }

        public int? filed_airspeed_kts { set; get; }

        public int? filed_airspeed_mach { set; get; }

        public int? filed_altitude { set; get; }

        public Timestamp filed_arrival_time { set; get; }

        public Timestamp filed_blockin_time { set; get; }

        public Timestamp filed_blockout_time { set; get; }

        public Timestamp filed_departure_time { set; get; }

        public int? filed_ete { set; get; }

        public string flightnumber { set; get; }

        public string full_aircrafttype { set; get; }

        public string gate_dest { set; get; }

        public string gate_orig { set; get; }

        public string ident { set; get; }

        public string inbound_faFlightID { set; get; }

        public AirportInfoResult origin { set; get; }

        public int? progress_percent { set; get; }

        public string route { set; get; }

        public int? seats_cabin_business { set; get; }

        public int? seats_cabin_coach { set; get; }

        public int? seats_cabin_first { set; get; }

        public string status { set; get; }

        public string tailnumber { set; get; }

        public string terminal_dest { set; get; }

        public string terminal_orig { set; get; }

        public string type { set; get; }

    }
}