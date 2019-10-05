using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class AirportBoardsResult
    {
        public string airport { set; get; }

        public AirportStruct airport_info { set; get; }
    }
}