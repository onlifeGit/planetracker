using app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Business.Interfaces
{
    public interface IAuthenticationHandler
    {
        int CreateUser(UsersVM user);
        int UpdateUser(UsersVM user);
        bool Autorize(string login, string password);
        int RestorePassword(string email);
        bool ChangePassword(int id, string password);
        bool LogOut();
    }
}