using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Features.Features.REST
{
    public class ResponceModel<TModel,TError>
    {
        public ResponceModel()
        {
            this.Status = new ResponceStatus<TError>();
        }

        public ResponceStatus<TError> Status { get; set; }
        public TModel Responce { get; set; }
    }
}