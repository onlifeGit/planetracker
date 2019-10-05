using app.Business;
using app.Extensions;
using app.Models;
using app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.Repo
{
    public class UsersRepo : AppRepo
    {
        public IEnumerable<UsersVM> GetItems()
        {
            return SelectItems().ToViewModel();
        }
        public UsersVM GetItem(int id)
        {
            return SelectItem(id).ToViewModel();
        }
        public UsersVM GetItemByEmail(string email)
        {
            return SelectItemByEmail(email).ToViewModel();
        }

        public int Add(UsersVM item)
        {
            return Insert(item.ToModel());
        }
        public bool Set(UsersVM item)
        {
            return Update(item.ToModel());
        }
        public bool Remove(int id)
        {
            return Delete(id);
        }

        #region DB Direct
        public IEnumerable<Users> SelectItems()
        {
            try
            {
                List<Users> items = null;

                using (SqlConnection db = new SqlConnection())
                {
                    items = db.Users.ToList();
                }

                Logger.SaveLog(LogTypes.Info, "UsersRepo.SelectItems", "Success users selecting");

                return items;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return null;
            }
        }
        public Users SelectItem(int id)
        {
            try
            {
                Users item = null;

                using (SqlConnection db = new SqlConnection())
                {
                    item = db.Users.FirstOrDefault(t => t.Id == id);
                }

                Logger.SaveLog(LogTypes.Info, "UsersRepo.SelectItem", $"Success user {item.Email} selecting");

                return item;
            }
            catch (Exception e)
            {

                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);
                return null;
            }
        }
        public Users SelectItemByEmail(string email)
        {
            try
            {
                Users item = null;

                using (SqlConnection db = new SqlConnection())
                {
                    item = db.Users.FirstOrDefault(t => t.Email == email);
                }

                if (item != null)
                {
                    Logger.SaveLog(LogTypes.Info, "UsersRepo.SelectItemByEmail", $"Success user {item.Email} selecting");

                    return item;
                }
                else
                {
                    Logger.SaveLog(LogTypes.Info, "UsersRepo.SelectItemByEmail", $"Not found item {item.Email}");

                    return null;
                }
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return null;
            }
        }

        private int Insert(Users item)
        {
            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    db.Users.Add(item);

                    db.SaveChanges();
                }

                Logger.SaveLog(LogTypes.Info, "UsersRepo.Inser", $"Success new user {item.Email} inserting");

                return item.Id;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return 0;
            }
        }
        private bool Update(Users item)
        {
            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    var record = db.Users.FirstOrDefault(t => t.Id == item.Id);

                    record.Id = item.Id;
                    record.FName = item.FName;
                    record.LName = item.LName;
                    record.MName = item.MName;
                    record.BDay = item.BDay;
                    record.Gender = item.Gender;
                    record.Phone = item.Phone;
                    record.Email = item.Email;
                    record.TwitterId = item.TwitterId;
                    record.Created = item.Created;

                    db.SaveChanges();
                }

                Logger.SaveLog(LogTypes.Info, "UsersRepo", $"Success user updating {item.Email}");

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
                    var record = db.Users.FirstOrDefault(t => t.Id == id);

                    db.Users.Remove(record);

                    db.SaveChanges();
                }

                Logger.SaveLog(LogTypes.Info, "UsersRepo.Delete", $"User was successfully deleted");

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