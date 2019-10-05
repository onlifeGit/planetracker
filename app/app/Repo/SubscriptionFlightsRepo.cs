using app.Business;
using app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Repo
{
    public class SubscriptionFlightsRepo
    {
        public IEnumerable<SubscriptionFlights> GetItems()
        {
            return SelectItems();
        }

        public SubscriptionFlights GetItem(int id)
        {
            return SelectItem(id);
        }

        public int Add(SubscriptionFlights item)
        {
            return Insert(item);
        }

        public bool Set(SubscriptionFlights item)
        {
            return Update(item);
        }

        public bool Remove(int id)
        {
            return Delete(id);
        }

        public IEnumerable<SubscriptionFlights> SelectItemByFlightId(string flightId)
        {
            try
            {
                List<SubscriptionFlights> flights = new List<SubscriptionFlights>();

                using (SqlConnection db = new SqlConnection())
                {
                    var item = db.SubscriptionFlights.Where(t => t.FlightId == flightId);

                    foreach(SubscriptionFlights f in item)
                    {
                        flights.Add(f);
                    }
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionFlightsRepo.SelectItemByFlightId", $"Success flights selecting");

                return flights;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return null;
            }
        }



        public IEnumerable<SubscriptionFlights> SelectItemsByUserId(int userId)
        {
            try
            {
                List<SubscriptionFlights> list = new List<SubscriptionFlights>();

                using (SqlConnection db = new SqlConnection())
                {
                    var item = db.SubscriptionFlights.Where(t => t.UserId == userId);

                    foreach(SubscriptionFlights c in item)
                    {
                        list.Add(c);
                    }
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionFlightsRepo.SelectItemsByUserId", $"Success items {list.ToString()} selecting");

                return list;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return null;
            }
        }

        #region private
        private IEnumerable<SubscriptionFlights> SelectItems()
        {
            try
            {
                List<SubscriptionFlights> value = null;

                using (SqlConnection db = new SqlConnection())
                {
                    value = db.SubscriptionFlights.ToList();
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionFlightsRepo.SelectItems", "Flights were successfully selected");

                return value;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return null;
            }
        }

        private SubscriptionFlights SelectItem(int id)
        {
            try
            {
                SubscriptionFlights value = null;

                using (SqlConnection db = new SqlConnection())
                {
                    value = db.SubscriptionFlights.FirstOrDefault(t => t.Id == id);
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionFlightsRepo.SelectItem", "Flight was successfully selected");

                return value;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return null;
            }
        }

        private int Insert(SubscriptionFlights item)
        {
            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    db.SubscriptionFlights.Add(item);

                    db.SaveChanges();
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionFlightsRepo.Insert", $"Flight was successfully inserted");

                return item.Id;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return 0;
            }
        }

        private bool Update(SubscriptionFlights item)
        {
            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    var record = db.SubscriptionFlights.FirstOrDefault(t => t.Id == item.Id);

                    record.Id = item.Id;
                    record.FlightId = item.FlightId;
                    record.UserId = item.UserId;
                    record.Created = item.Created;

                    db.SaveChanges();
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionFlightsRepo.Update", "Flight was successfully updated");

                return true;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return false;
            }
        }

        private bool Delete(int id)
        {
            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    var record = db.SubscriptionFlights.FirstOrDefault(t => t.Id == id);

                    db.SubscriptionFlights.Remove(record);

                    db.SaveChanges();
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionFlightsRepo.Delete", "Flight was successfully deleted");

                return true;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return false;
            }
        }
        #endregion

    }
}