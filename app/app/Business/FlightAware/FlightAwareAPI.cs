using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using app.Business.FlightAware.Models.OutputModels;
using app.Business.FlightAware.Models.InputModels;
using app.Features.REST;
using Flurl;
using app.Business.FlightAware.Models;

namespace app.Business.FlightAware
{
    public class FlightAwareAPI
    {
        private static string _apiConnectionString = "http://flightxml.flightaware.com/json/FlightXML3/";
        //private static string _username = "demonatom";
        //private static string _apiKey = "ca416cc61201dda4541177e51fec1c80c55467f7";
        //private static string _username = "alexxustt";
        //private static string _apiKey = "c239c819bcd8b177d17f87cc61c87968f1ae5495";
        //private static string _username = "onlife";
        //private static string _apiKey = "6cf0a286968a4390c3ab6d977755a8a41a7149bc";
        private static string _username = "xubuxa";
        private static string _apiKey = "53be4f7f1ec3ee6031d97eb561c2f6baea6dddbe";
        private static byte[] _credentials = Encoding.ASCII.GetBytes(_username + ":" + _apiKey);
        private const string checkfield = "error";


        #region flight
        public AircraftTypeResult GetAircraftType(string type)
        {
            IApiConnector<AircraftTypeResult, ApiError> connector = new ApiConnector<AircraftTypeResult, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("AircraftType")
                            .SetQueryParams(new
                            {
                                type = type
                            });


            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public FindFlightResult GetFindFlight(FindFlight model)
        {
            IApiConnector<FindFlightResult, ApiError> connector = new ApiConnector<FindFlightResult, ApiError>();

            var requestUrl = _apiConnectionString
                           .AppendPathSegment("FindFlight")
                           .SetQueryParams(new
                           {
                               origin = model.origin,
                               destination = model.destination,
                               include_ex_data = model.include_ex_data,
                               type = model.type,
                               filter = model.filter,
                               howMany = model.howMany,
                               offset = model.offset
                           });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public FlightInfoStatusResult GetFlightInfoStatus(FlightInfoStatus model)
        {
            IApiConnector<FlightInfoStatusResult, ApiError> connector = new ApiConnector<FlightInfoStatusResult, ApiError>();

            var requestUrl = _apiConnectionString
                           .AppendPathSegment("FlightInfoStatus")
                           .SetQueryParams(new
                           {
                               ident = model.ident,
                               include_ex_data = model.include_ex_data,
                               filter = model.filter,
                               howMany = model.howMany,
                               offset = model.offset

                           });
            
            var res = connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;

            return res;
        }

        public GetFlightTrackResult GetFlightTrack(GetFlightTrack model)
        {
            IApiConnector<GetFlightTrackResult, ApiError> connector = new ApiConnector<GetFlightTrackResult, ApiError>();

            var requestUrl = _apiConnectionString
                           .AppendPathSegment("GetFlightTrack")
                           .SetQueryParams(new
                           {
                               ident = model.ident,
                               include_position_estimates = model.include_position_estimates
                           });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public DecodeFlightRouteResult GetDecodeFlightRoute(string faFlightID)
        {
            IApiConnector<DecodeFlightRouteResult, ApiError> connector = new ApiConnector<DecodeFlightRouteResult, ApiError>();

            var requestUrl = _apiConnectionString
                     .AppendPathSegment("DecodeFlightRoute")
                     .SetQueryParams(new
                     {
                         faFlightID = faFlightID
                     });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public DecodeRouteResult GetDecodeRoute(DecodeRoute model)
        {
            IApiConnector<DecodeRouteResult, ApiError> connector = new ApiConnector<DecodeRouteResult, ApiError>();

            var requestUrl = _apiConnectionString
                  .AppendPathSegment("DecodeRoute")
                  .SetQueryParams(new
                  {
                      origin = model.origin,
                      route = model.route,
                      destination = model.destination
                  });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public RoutesBetweenAirportsResult GetRoutesBetweenAirports(RoutesBetweenAirports model)
        {
            IApiConnector<RoutesBetweenAirportsResult, ApiError> connector = new ApiConnector<RoutesBetweenAirportsResult, ApiError>();

            var requestUrl = _apiConnectionString
                  .AppendPathSegment("RoutesBetweenAirports")
                  .SetQueryParams(new
                  {
                      origin = model.origin,
                      destination = model.destination,
                      max_file_age = model.max_file_age,
                      sort_by = model.sort_by,
                      howMany = model.howMany,
                      offset = model.offset
                  });
            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;

        }
        #endregion

        #region company
        public AirlineInfoResult GetAirlineInfo(string airlineCode)
        {
            IApiConnector<AirlineInfoResult, ApiError> connector = new ApiConnector<AirlineInfoResult, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("AirlineInfo")
                            .SetQueryParams(new
                            {
                                airline_code = airlineCode
                            });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public TailOwnerResult GetTailOwner(string ident)
        {
            IApiConnector<TailOwnerResult, ApiError> connector = new ApiConnector<TailOwnerResult, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("TailOwner")
                            .SetQueryParams(new
                            {
                                ident = ident
                            });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;

        }
        #endregion

        #region airport
        public AirportInfoResult GetAirportInfo(string airportCode)
        {
            IApiConnector<AirportInfoResult, ApiError> connector = new ApiConnector<AirportInfoResult, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("AirportInfo")
                            .SetQueryParams(new
                            {
                                airport_code = airportCode
                            });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public AirportBoardsResult GetAirportBoards(AirportBoards model)
        {
            IApiConnector<AirportBoardsResult, ApiError> connector = new ApiConnector<AirportBoardsResult, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("AirportBoards")
                            .SetQueryParams(new
                            {
                                airport_code = model.airport_code,
                                include_ex_data = model.include_ex_data,
                                filter = model.filter,
                                type = model.type,
                                howMany = model.howMany,
                                offset = model.offset
                            });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public AirportDelaysResult GetAirportDelays(AirportDelays model)
        {
            IApiConnector<AirportDelaysResult, ApiError> connector = new ApiConnector<AirportDelaysResult, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("AirportDelays")
                            .SetQueryParams(new
                            {
                                airport_code = model.airport_code,
                                howMany = model.howMany,
                                offset = model.offset
                            });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public BlockIdentCheckResults GetBlockIdentCheck(string ident)
        {
            IApiConnector<BlockIdentCheckResults, ApiError> connector = new ApiConnector<BlockIdentCheckResults, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("BlockIdentCheck")
                            .SetQueryParams(new
                            {
                                ident = ident
                            });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public AirlineFlightSchedulesResult GetAirlineFlightSchedules(AirlineFlightSchedules model)
        {
            IApiConnector<AirlineFlightSchedulesResult, ApiError> connector = new ApiConnector<AirlineFlightSchedulesResult, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("AirlineFlightSchedules")
                            .SetQueryParams(new
                            {
                                start_date = model.start_date,
                                end_date = model.end_date,
                                destination = model.destination,
                                airline = model.airline,
                                flightno = model.flightno,
                                exclude_codeshare = model.exclude_codeshare,
                                howMany = model.howMany,
                                offset = model.offset
                            });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }
        public CountAirportOperationsResult GetCountAirportOperations(string airportCode)
        {
            IApiConnector<CountAirportOperationsResult, ApiError> connector = new ApiConnector<CountAirportOperationsResult, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("CountAirportOperations")
                            .SetQueryParams(new
                            {
                                airport_code = airportCode
                            });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public CountAllEnrouteAirlineOperationsResult GetCountAllEnrouteAirlineOperations()
        {
            IApiConnector<CountAllEnrouteAirlineOperationsResult, ApiError> connector = new ApiConnector<CountAllEnrouteAirlineOperationsResult, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("CountAllEnrouteAirlineOperations")
                            .SetQueryParams(new
                            {

                            });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        #endregion

        #region add
        public FlightCancellationStatisticsResult GetFlightCancellationStatistics(FlightCancellationStatistics model)
        {
            IApiConnector<FlightCancellationStatisticsResult, ApiError> connector = new ApiConnector<FlightCancellationStatisticsResult, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("FlightCancellationStatistics")
                            .SetQueryParams(new
                            {
                                time_period = model.time_period,
                                type_matching = model.type_matching,
                                ident_filter = model.ident_filter,
                                howMany = model.howMany,
                                offset = model.offset
                            });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public LatLongsToHeadingResults GetLatLongsToHeading(LatLongsToHeading model)
        {
            IApiConnector<Models.OutputModels.LatLongsToHeadingResults, ApiError> connector = new ApiConnector<Models.OutputModels.LatLongsToHeadingResults, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("LatLongsToHeading")
                            .SetQueryParams(new
                            {
                                lat1 = model.lat1,
                                lon1 = model.lon1,
                                lat2 = model.lat2,
                                lon2 = model.lon2
                            });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        public LatLongsToDistanceResults GetLatLongsToDistance(LatLongsToDistance model)
        {
            IApiConnector<Models.OutputModels.LatLongsToDistanceResults, ApiError> connector = new ApiConnector<Models.OutputModels.LatLongsToDistanceResults, ApiError>();

            var requestUrl = _apiConnectionString
                            .AppendPathSegment("LatLongsToDistance")
                            .SetQueryParams(new
                            {
                                lat1 = model.lat1,
                                lon1 = model.lon1,
                                lat2 = model.lat2,
                                lon2 = model.lon2
                            });

            return connector.GetRequest(requestUrl, checkfield, "Basic", _credentials).Responce;
        }

        #endregion
    }
}