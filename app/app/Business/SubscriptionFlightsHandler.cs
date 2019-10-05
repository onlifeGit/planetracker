using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using app.Repo;
using app.Business.Interfaces;
using app.Models;

namespace app.Business
{
    public class SubscriptionFlightsHandler
    {
        SubscriptionFlightsRepo _subFlights = new SubscriptionFlightsRepo();
        UsersRepo _user = new UsersRepo();

        public string Subscribe(string flightId)
        {
            try
            {
                var userSets = HttpContext.Current.Request.Cookies["user_login"];
                var user = _user.SelectItemByEmail(userSets.Value);
                var userFlights = _subFlights.SelectItemsByUserId(user.Id);
                var flight = _subFlights.SelectItemByFlightId(flightId);

                if (flightId != null)
                {
                    if (userSets.Value != null)
                    {
                        if (userFlights.Count() != 0 || flight.Count() != 0)
                        {
                            foreach (var t in userFlights)
                            {
                                foreach (var k in flight)
                                {
                                    if (t.UserId != k.UserId)
                                    {
                                        var subflight = new SubscriptionFlights()
                                        {
                                            FlightId = flightId,
                                            UserId = user.Id,
                                            Created = DateTime.Now
                                        };

                                        _subFlights.Add(subflight);

                                        Logger.SaveLog(LogTypes.Info, "SubscriptionFlightsHandler.Subscribe", "Successfully subscribing");

                                        return "OK";
                                    }

                                    if (k == flight.Last())
                                    {
                                        return "Exist";
                                    }
                                }
                            }
                        }

                        var result = new SubscriptionFlights()
                        {
                            FlightId = flightId,
                            UserId = user.Id,
                            Created = DateTime.Now
                        };

                        _subFlights.Add(result);

                        Logger.SaveLog(LogTypes.Info, "SubscriptionFlightsHandler.Subscribe", "Successfully subscribing");

                        return "OK";
                    }

                    return "NoAuth";
                }

                return "Error";
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return "NoAuth";
            }
        }

        public bool Unsubscribe(string flightId)
        {
            try
            {
                var userSets = HttpContext.Current.Request.Cookies["user_login"];
                var user = _user.SelectItemByEmail(userSets.Value);
                var userFlights = _subFlights.SelectItemsByUserId(user.Id);
                var flight = _subFlights.SelectItemByFlightId(flightId);

                if (userSets.Value != null)
                {
                    foreach (var t in userFlights)
                    {
                        foreach (var k in flight)
                        {
                            if (t.UserId == k.UserId && flightId != null)
                            {
                                var result = _subFlights.Remove(k.Id);

                                if (result)
                                    Logger.SaveLog(LogTypes.Info, "SubscriptionFlightsHandler.Unsubscribe", "Successfully unsubscribing");
                                else
                                    Logger.SaveLog(LogTypes.Error, "SubscriptionFlightsHandler.Unsubscribe", "Failed unsubscribing");

                                return result;
                            }
                        }
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, "SubscriptionFlightsHandler.Unsubscribe", "Failed unsubscribing");

                return false;
            }
        }

        public List<string> SubscribedFlights(string email)
        {
            if (email != null)
            {
                if (_user.SelectItemByEmail(email) != null)
                {
                    List<string> flights = new List<string>();

                    var user = _user.SelectItemByEmail(email);
                    var list = _subFlights.SelectItemsByUserId(user.Id);

                    if (list.Count() != 0)
                    {
                        foreach (var str in list)
                        {
                            flights.Add(str.FlightId);
                        }

                        return flights;
                    }
                }
            }
            return null;
        }
    }
}