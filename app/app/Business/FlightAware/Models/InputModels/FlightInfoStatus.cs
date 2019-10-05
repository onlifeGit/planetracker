using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class FlightInfoStatus
    {
        public string ident { set; get; }

        public bool? include_ex_data { set; get; }

        public string filter { set; get; }

        public int? howMany { set; get; }

        public int? offset { set; get; }
    }
}