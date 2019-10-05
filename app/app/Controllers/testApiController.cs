using app.Business.FlightAware;
using app.Business.FlightAware.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app.Controllers
{
    public class testApiController : Controller
    {
        FlightAwareAPI _flightAwareAPI = new FlightAwareAPI();

        // GET: testApi
        public JsonResult aircraftType(string type)
        {
            return Json(_flightAwareAPI.GetAircraftType(type), JsonRequestBehavior.AllowGet);
        }

        public JsonResult findFlight(FindFlight model)
        {
            return Json(_flightAwareAPI.GetFindFlight(model), JsonRequestBehavior.AllowGet);
        }

        public JsonResult flightInfoStatus(FlightInfoStatus model)
        {
            return Json(_flightAwareAPI.GetFlightInfoStatus(model), JsonRequestBehavior.AllowGet);
        }

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

        public JsonResult routesBetweenAirports(RoutesBetweenAirports model)
        {
            return Json(_flightAwareAPI.GetRoutesBetweenAirports(model), JsonRequestBehavior.AllowGet);
        }

        public JsonResult airlineInfo(string type)
        {
            return Json(_flightAwareAPI.GetAirlineInfo(type), JsonRequestBehavior.AllowGet);
        }

        public JsonResult tailOwner(string type)
        {
            return Json(_flightAwareAPI.GetTailOwner(type), JsonRequestBehavior.AllowGet);
        }

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
    }
}