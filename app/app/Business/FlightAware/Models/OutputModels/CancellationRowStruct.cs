using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class CancellationRowStruct
    {
        public int cancellations { set; get; }

        public int delays { set; get; }

        public string description { set; get; }

        public string ident { set; get; }

        public int total { set; get; }
    }
}