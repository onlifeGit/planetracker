using app.Models;
using app.Repo;
using app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business
{
    public class UsersHandler
    {
        UsersRepo _user = new UsersRepo();

        public UsersVM GetUser(string email)
        {
            var user = _user.GetItemByEmail(email);

            return user;
        }
    }
}