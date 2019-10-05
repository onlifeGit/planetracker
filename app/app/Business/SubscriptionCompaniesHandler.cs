using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using app.Repo;
using app.Models;

namespace app.Business
{
    public class SubscriptionCompaniesHandler
    {
        SubscriptionCompaniesRepo _subCompany = new SubscriptionCompaniesRepo();
        UsersRepo _user = new UsersRepo();

        public string Subscribe(string companyId)
        {
            try
            {
                var userSets = HttpContext.Current.Request.Cookies["user_login"];
                var user = _user.SelectItemByEmail(userSets.Value);
                var userCompany = _subCompany.SelectItemsByUserId(user.Id);
                var company = _subCompany.SelectItemByCompanyId(companyId);

                if (companyId != null)
                {
                    if (userSets.Value != null)
                    {
                        if (userCompany.Count() != 0 || company.Count() != 0)
                        {
                            foreach (var t in userCompany)
                            {
                                foreach (var k in company)
                                {
                                    if (t.UserId != k.UserId && companyId != null)
                                    {
                                        var subCompany = new SubscriptionCompanies()
                                        {
                                            CompanyId = companyId,
                                            UserId = user.Id,
                                            Created = DateTime.Now
                                        };

                                        _subCompany.Add(subCompany);

                                        Logger.SaveLog(LogTypes.Info, "SubscriptionFlightsHandler.Subscribe", "Successfully subscribing");

                                        return "OK";
                                    }

                                    if (k == company.Last())
                                    {
                                        return "Exist";
                                    }
                                }
                            }
                        }

                        var result = new SubscriptionCompanies()
                        {
                            CompanyId = companyId,
                            UserId = user.Id,
                            Created = DateTime.Now
                        };

                        _subCompany.Add(result);

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

        public bool Unsubscribe(string companyId)
        {
            try
            {
                var userSets = HttpContext.Current.Request.Cookies["user_login"];
                var user = _user.SelectItemByEmail(userSets.Value);
                var userCompany = _subCompany.SelectItemsByUserId(user.Id);
                var company = _subCompany.SelectItemByCompanyId(companyId);

                if (userSets.Value != null)
                {
                    foreach (var t in userCompany)
                    {
                        foreach(var k in company)
                        {
                            if (t.UserId == k.UserId && companyId != null)
                            {
                                var result = _subCompany.Remove(k.Id);

                                if (result)
                                    Logger.SaveLog(LogTypes.Info, "SubscriptionCompaniesHandler.Unsubscribe", "Successfully unsubscribing");
                                else
                                    Logger.SaveLog(LogTypes.Error, "SubscriptionCompaniesHandler.Unsubscribe", "Failed unsubscribing");

                                return result;
                            }
                        }
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", e.Message, e.StackTrace);

                return false;
            }
        }

        public List<string> SubscribedCompanies(string email)
        {
            if (email != null)
            {
                if (_user.SelectItemByEmail(email) != null)
                {
                    List<string> companies = new List<string>();

                    var user = _user.SelectItemByEmail(email);
                    var list = _subCompany.SelectItemsByUserId(user.Id);

                    if (list.Count() != 0)
                    {
                        foreach (var str in list)
                        {
                            companies.Add(str.CompanyId);
                        }

                        return companies;
                    }
                }
            }

            return null;
        }

    }
}