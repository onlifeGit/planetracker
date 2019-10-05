using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using app.Business.FlightAware.Models.OutputModels;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System.Dynamic;
using app.Business.Helpers;

namespace app.Features.REST
{
    public class ApiConnector<TOut, TError> : IApiConnector<TOut, TError>
    {
        public ResponceModel<TOut, TError> GetRequest(string url, string checkfield, string authScheme = null, byte[] credentials = null)
        {
            TError error;
            var apiResponce = new ResponceModel<TOut, TError>();

            var responceResult = Client(url, authScheme, credentials);
            
            try
            {
                var result = Parsers.ParseOutput(responceResult, typeof(TOut).Name);

                try
                {
                    error = JsonConvert.DeserializeObject<TError>(result);
                    if (Reflections.IsPropertyNull(error, checkfield))
                        throw new Exception();

                    apiResponce.Responce = JsonConvert.DeserializeObject<TOut>(result);
                    apiResponce.Status.statusCode = HttpStatusCode.OK;

                    return apiResponce;
                }
                catch (Exception e)
                {
                    error = JsonConvert.DeserializeObject<TError>(result);

                    apiResponce.Status.statusCode = HttpStatusCode.BadRequest;
                    apiResponce.Status.message = result;
                    apiResponce.Status.error = error;

                    return apiResponce;
                }
            }
            catch (Exception e)
            {
                apiResponce.Status.statusCode = HttpStatusCode.InternalServerError;
                apiResponce.Status.message
                    = $"ApiConnector fatal error\n Model: {typeof(TOut).Name}\n Link: {url}\n Exception message: {e.Message.ToString()}";

                return apiResponce;
            }
        }

        private string Client(string url, string authScheme = null, byte[] credentials = null)
        {
            var client = new HttpClient();

            if (credentials != null)
            {
                client.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue(authScheme, Convert.ToBase64String(credentials));
            }

            var responce = client.GetAsync(url);
            if (responce == null)
                throw new Exception();

            var responceResult = responce.Result.Content.ReadAsStringAsync();

            return responceResult.Result;
        }        
    }
}