using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Features.Features.REST
{
    public class ResponceStatus<TError>
    {
        public HttpStatusCode statusCode { get; set; }
        public string message { get; set; }
        public TError error { get; set; }
    }
}