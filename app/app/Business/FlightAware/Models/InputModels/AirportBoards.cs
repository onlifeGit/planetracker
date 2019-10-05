using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class AirportBoards
    {
        public string airport_code { set; get; }

        public Nullable<bool> include_ex_data { set; get; }

        public string filter { set; get; }

        public string type { set; get; }

        public Nullable<int> howMany { set; get; }

        public Nullable<int> offset { set; get; }
    }
}