using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class FindFlight
    {
        public string origin { set; get; }

        public string destination { set; get; }

        public Nullable<bool> include_ex_data { set; get; }

        public string type { set; get; }

        public string filter { set; get; }

        public int? howMany { set; get; }

        public int? offset { set; get; }

    }
}