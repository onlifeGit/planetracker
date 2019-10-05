using app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Repo
{
    public class LogsRepo
    {

        public IEnumerable<Logs> GetItems()
        {
            return SelectItems();
        }

        public Logs GetItem(int id)
        {
            return SelectItem(id);
        }

        public int Add(Logs item)
        {
            return Insert(item);
        }

        public bool Set(Logs item)
        {
            return Update(item);
        }

        public bool Remove(int id)
        {
            return Delete(id);
        }

        #region private
        private IEnumerable<Logs> SelectItems()
        {
            try
            {
                List<Logs> value = null;

                using (SqlConnection db = new SqlConnection())
                {
                    value = db.Logs.ToList();
                }

                return value;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private Logs SelectItem(int id)
        {
            try
            {
                Logs value = null;

                using (SqlConnection db = new SqlConnection())
                {
                    value = db.Logs.FirstOrDefault(t => t.Id == id);
                }

                return value;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private int Insert(Logs item)
        {
            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    db.Logs.Add(item);

                    db.SaveChanges();
                }

                return item.Id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private bool Update(Logs item)
        {
            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    var record = db.Logs.FirstOrDefault(t => t.Id == item.Id);

                    record.Id = item.Id;
                    record.Type = item.Type;
                    record.Method = item.Method;
                    record.Message = item.Message;
                    record.Stack = item.Stack;
                    record.Created = record.Created;

                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool Delete(int id)
        {
            try
            {
                using (SqlConnection db = new SqlConnection())
                {
                    var record = db.Logs.FirstOrDefault(t => t.Id == id);

                    db.Logs.Remove(record);

                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion

    }
}