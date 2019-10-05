using app.Business;
using app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Repo
{
    public class SubscriptionCompaniesRepo
    {
        public IEnumerable<SubscriptionCompanies> GetItems()
        {
            return SelectItems();
        }

        public SubscriptionCompanies GetItem(int id)
        {
            return SelectItem(id);
        }

        public int Add(SubscriptionCompanies item)
        {
            return Insert(item);
        }

        public bool Set(SubscriptionCompanies item)
        {
            return Update(item);
        }

        public bool Remove(int id)
        {
            return Delete(id);
        }


        public IEnumerable<SubscriptionCompanies> SelectItemByCompanyId(string companyId)
        {
            try
            {
                List<SubscriptionCompanies> company = new List<SubscriptionCompanies>();

                using (SqlConnection db = new SqlConnection())
                {
                    var item = db.SubscriptionCompanies.Where(t => t.CompanyId == companyId);

                    foreach (SubscriptionCompanies c in item)
                    {
                        company.Add(c);
                    }
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionCompaniesRepo.SelectItemByCompanyId", $"Success companies selecting");

                return company;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return null;
            }
        }

        public IEnumerable<SubscriptionCompanies> SelectItemsByUserId(int userId)
        {
            try
            {
                List<SubscriptionCompanies> list = new List<SubscriptionCompanies>();

                using (SqlConnection db = new SqlConnection())
                {
                    var item = db.SubscriptionCompanies.Where(t => t.UserId == userId);

                    foreach (SubscriptionCompanies c in item)
                    {
                        list.Add(c);
                    }
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionCompaniesRepo.SelectItemsByUserId", $"Success items {list.ToString()} selecting");

                return list;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return null;
            }
        }

        #region private

        private IEnumerable<SubscriptionCompanies> SelectItems()
        {
            try
            {
                List<SubscriptionCompanies> value = null;

                using (SqlConnection db = new SqlConnection())
                {
                    value = db.SubscriptionCompanies.ToList();
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionCompaniesRepo.SelectItems", "Companies were successfully selected");

                return value;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return null;
            }
        }

        private SubscriptionCompanies SelectItem(int id)
        {
            try
            {
                SubscriptionCompanies item = null;

                using (SqlConnection db = new SqlConnection())
                {
                    item = db.SubscriptionCompanies.FirstOrDefault(t => t.Id == id);
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionCompaniesRepo.SelectItem", "Company was successfully selected");

                return item;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return null;
            }
        }

        private int Insert(SubscriptionCompanies item)
        {
            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    db.SubscriptionCompanies.Add(item);

                    db.SaveChanges();
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionCompaniesRepo.Insert", "Company was successfully inserted");

                return item.Id;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return 0;
            }
        }

        private bool Update(SubscriptionCompanies item)
        {
            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    var record = db.SubscriptionCompanies.FirstOrDefault(t => t.Id == item.Id);

                    record.Id = item.Id;
                    record.CompanyId = item.CompanyId;
                    record.UserId = item.UserId;
                    record.Created = item.Created;

                    db.SaveChanges();
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionCompaniesRepo.Update", "Company was successfully updated");

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
                    var record = db.SubscriptionCompanies.FirstOrDefault(t => t.Id == id);

                    db.SubscriptionCompanies.Remove(record);

                    db.SaveChanges();
                }

                Logger.SaveLog(LogTypes.Info, "SubscriptionCompaniesRepo.Delete", "Company was successfully deleted");

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