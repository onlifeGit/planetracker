using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using app.Filters;
using app.Business.FlightAware;
using app.Business.FlightAware.Models.InputModels;
using app.Business;
using app.ViewModel;
using app.Business.FlightAware.Models.OutputModels;
using System.Threading.Tasks;
using System.Threading;

namespace app.Controllers
{
    public class homeController : Controller
    {
        FlightAwareAPI _flightAwareAPI = new FlightAwareAPI();
        SubscriptionFlightsHandler _subFlight = new SubscriptionFlightsHandler();
        SubscriptionCompaniesHandler _subCompany = new SubscriptionCompaniesHandler();
        UsersHandler _user = new UsersHandler();
        Mailler _postBack = new Mailler();

        public ActionResult index()
        {
            _postBack.Send("planetrackerteam@gmail.com", "planetrackerteam@gmail.com", "lol", "kek");

            return View();
        }

        #region flight
        [AuthFilter]
        public JsonResult aircraftType(string type)
        {
            return Json(_flightAwareAPI.GetAircraftType(type), JsonRequestBehavior.AllowGet);
        }
        [AuthFilter]
        public JsonResult findFlight(FindFlight model)
        {
            return Json(_flightAwareAPI.GetFindFlight(model), JsonRequestBehavior.AllowGet);
        }
        [AuthFilter]
        public JsonResult flightInfoStatus(FlightInfoStatus model)
        {
            return Json(_flightAwareAPI.GetFlightInfoStatus(model), JsonRequestBehavior.AllowGet);
        }
        [AuthFilter]
        public JsonResult flightTrack(GetFlightTrack model)
        {
            return Json(_flightAwareAPI.GetFlightTrack(model), JsonRequestBehavior.AllowGet);
        }

        public JsonResult decodeFlightRoute(string type)
        {
            return Json(_flightAwareAPI.GetDecodeFlightRoute(type), JsonRequestBehavior.AllowGet);
        }

        public JsonResult decodeRoute(DecodeRoute model)
        {
            return Json(_flightAwareAPI.GetDecodeRoute(model), JsonRequestBehavior.AllowGet);
        }

        [AuthFilter]
        public JsonResult routesBetweenAirports(RoutesBetweenAirports model)
        {
            return Json(_flightAwareAPI.GetRoutesBetweenAirports(model), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region company
        public JsonResult airlineInfo(string type)
        {
            return Json(_flightAwareAPI.GetAirlineInfo(type), JsonRequestBehavior.AllowGet);
        }

        public JsonResult tailOwner(string type)
        {
            return Json(_flightAwareAPI.GetTailOwner(type), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region airport
        public JsonResult airportInfo(string type)
        {
            return Json(_flightAwareAPI.GetAirportInfo(type), JsonRequestBehavior.AllowGet);
        }

        public JsonResult airportBoards(AirportBoards model)
        {
            return Json(_flightAwareAPI.GetAirportBoards(model), JsonRequestBehavior.AllowGet);
        }

        public JsonResult airportDelays(AirportDelays model)
        {
            return Json(_flightAwareAPI.GetAirportDelays(model), JsonRequestBehavior.AllowGet);
        }

        public JsonResult blockIdentCheck(string type)
        {
            return Json(_flightAwareAPI.GetBlockIdentCheck(type), JsonRequestBehavior.AllowGet);
        }

        public JsonResult airlineFlightSchedules(AirlineFlightSchedules model)
        {
            return Json(_flightAwareAPI.GetAirlineFlightSchedules(model), JsonRequestBehavior.AllowGet);
        }

        public JsonResult countAirportOperations(string type)
        {
            return Json(_flightAwareAPI.GetCountAirportOperations(type), JsonRequestBehavior.AllowGet);
        }

        public JsonResult countAllEnrouteAirlineOperations()
        {
            return Json(_flightAwareAPI.GetCountAllEnrouteAirlineOperations(), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region add
        public JsonResult flightCancellationStatistics(FlightCancellationStatistics model)
        {
            return Json(_flightAwareAPI.GetFlightCancellationStatistics(model), JsonRequestBehavior.AllowGet);
        }

        public JsonResult latLongsToHeading(LatLongsToHeading model)
        {
            return Json(_flightAwareAPI.GetLatLongsToHeading(model), JsonRequestBehavior.AllowGet);
        }

        public JsonResult latLongsToDistance(LatLongsToDistance model)
        {
            return Json(_flightAwareAPI.GetLatLongsToDistance(model), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region subscriptionFlights

        public JsonResult subscribeFlight(string flightId)
        {
            return Json(_subFlight.Subscribe(flightId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult unsubscribeFlight(string flightId)
        {
            return Json(_subFlight.Unsubscribe(flightId), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region subscriptionCompanies
        public JsonResult subscribeCompany(string companyId)
        {
            return Json(_subCompany.Subscribe(companyId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult unsubscribeCompany(string companyId)
        {
            return Json(_subCompany.Unsubscribe(companyId), JsonRequestBehavior.AllowGet);
        }
#endregion

        public JsonResult GetFlightsInfoTrack(string ident)
        {
            FlightTrackInfoVM flight = new FlightTrackInfoVM();

            flight.Coordinates = _flightAwareAPI.GetFlightTrack(new GetFlightTrack
            {
                ident = ident
            });

            return Json(flight, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFlightsInfoStatus(string ident)
        {
            FlightInfoStatusVM flight = new FlightInfoStatusVM();

            flight.Info = _flightAwareAPI.GetFlightInfoStatus(new FlightInfoStatus { ident = ident });

            return PartialView("_FlightsInfoStatus", flight.Info);  
        }

        public ActionResult GetAirlineInfo(string ident)
        {
            AirlineInfoVM airline = new AirlineInfoVM();

            airline.Info = _flightAwareAPI.GetAirlineInfo(ident);

            return PartialView("_AirlineInfo", airline.Info);
        }


        public JsonResult GetFlightsCoordinate()
        {
            /*Problem with subscribe
            var end = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            var start = end - 3600;
            
            AirlineFlightSchedules date = new AirlineFlightSchedules()
            {
                start_date = Convert.ToInt32(start),
                end_date = Convert.ToInt32(end)
            };

            AirlineFlightSchedulesResult flights = _flightAwareAPI.GetAirlineFlightSchedules(date);
            */

            FlightVM flightVM = new FlightVM();
            List<FlightInfoVM> flightInfo = new List<FlightInfoVM>();

            TrackStruct track = new TrackStruct();
            FlightInfoStatusStruct infoStatus = new FlightInfoStatusStruct();  

            List<string> list = new List<string>();

            list.Add("AUI146-1512800764-airline-0169");    //Ukraine: AUI146-1512800764-airline-0169       
            list.Add("SIA321-1512973541-airline-0029");    //London SIA321-1512973541-airline-0029

            for (int i = 0; i < list.Count; i++)
            {
                FlightInfoVM flight = new FlightInfoVM();

                var coordinates = _flightAwareAPI.GetFlightTrack(new GetFlightTrack
                {
                    ident = list[i],
                    include_position_estimates = false
                });

                var info = _flightAwareAPI.GetFlightInfoStatus(new FlightInfoStatus
                {
                    ident = list[i],
                    include_ex_data = false,
                    howMany = 3
                });

                if (coordinates != null && info != null)
                {
                    track = coordinates.tracks.ToList().Last();
                    flight.Latitude = track.latitude;
                    flight.Longitude = track.longitude;

                    infoStatus = info.flights.ToList().Last();
                    flight.FlightId = infoStatus.faFlightID;
                    flight.Airline = infoStatus.airline.ToString();

                    flightInfo.Add(flight);
                }
            }

            flightVM.FlightInfoVM = flightInfo;

            try
            {
                var email = HttpContext.Request.Cookies["user_login"].Value;
                flightVM.Email = email;
            }
            catch(Exception e)
            {
                flightVM.Email = "Error";
            }

            return Json(flightVM, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFavouriteFlights()
        {
            FavouriteFlightsVM favourites = new FavouriteFlightsVM();

            try
            {
                var email = HttpContext.Request.Cookies["user_login"].Value;

                favourites.Companies = _subCompany.SubscribedCompanies(email);
                favourites.Flights = _subFlight.SubscribedFlights(email);
            }
            catch (Exception e)
            {
                return null;
            }

            return PartialView("_FavouriteFlights", favourites);
        }

        public JsonResult GetSubscribedFlights()
        {
            List<string> subFlights = new List<string>();

            try
            {
                var email = HttpContext.Request.Cookies["user_login"].Value;

                subFlights = _subFlight.SubscribedFlights(email);

                if(subFlights == null)
                {
                    subFlights = new List<string>();
                    subFlights.Add("Error");
                }
            }
            catch (Exception e)
            {
                subFlights = new List<string>();
                subFlights.Add("Error");
            }

            return Json(subFlights, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubscribedCompanies()
        {
            List<string> subCompany = new List<string>();

            try
            {
                var email = HttpContext.Request.Cookies["user_login"].Value;

                subCompany = _subCompany.SubscribedCompanies(email);

                if(subCompany == null)
                {
                    subCompany = new List<string>();
                    subCompany.Add("Error");
                }
                            
            }
            catch
            {
                subCompany = new List<string>();
                subCompany.Add("Error");
            }

            return Json(subCompany, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUserInfo()
        {
            string name = null;

            try
            {
                var email = HttpContext.Request.Cookies["user_login"].Value;

                var user = _user.GetUser(email);

                name = user.FName;

            }
            catch (Exception e)
            {
                name = "Error";
            }

            return Json(name, JsonRequestBehavior.AllowGet);
        }
    }
}