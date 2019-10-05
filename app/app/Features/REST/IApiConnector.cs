using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Features.REST
{
    public interface IApiConnector<TModel, TError>
    {
        ResponceModel<TModel,TError> GetRequest(string url, string checkfield, string authScheme = null, byte[] credentials = null);
    }
}