using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.InputModels
{
    public class DecodeRoute
    {
        public string origin { set; get; }

        public string route { set; get; }

        public string destination { set; get; }
    }
}