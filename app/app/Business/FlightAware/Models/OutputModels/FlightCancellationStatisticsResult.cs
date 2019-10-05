using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.FlightAware.Models.OutputModels
{
    public class FlightCancellationStatisticsResult
    {
        public IEnumerable<CancellationRowStruct> matching { set; get; }

        public int next_offset { set; get; }

        public int total_cancellations_national { set; get; }

        public int total_cancellations_worldwide { set; get; }

        public int total_delays_worldwide { set; get; }

        public string type_matching { set; get; }
    }
}