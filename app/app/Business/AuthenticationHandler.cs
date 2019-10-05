using app.Business.Interfaces;
using app.Models;
using app.Repo;
using app.ViewModel;
using System;
using System.Web;

namespace app.Business
{
    public class AuthenticationHandler : IAuthenticationHandler
    {
        UsersRepo _usersRepo = new UsersRepo();

        public bool Autorize(string login, string password)
        {
            var user = _usersRepo.SelectItemByEmail(login);

            if (user != null && user.Email == login && user.Password == password)
            {
                var expiresTime = DateTime.Now.AddMinutes(5);

                var userSets = new HttpCookie("session_time");

                userSets.Value = expiresTime.ToString("dd/MM/yyyy hh:mm:ss tt");
                userSets.Expires = expiresTime.AddHours(2);

                HttpContext.Current.Response.Cookies.Add(userSets);

                userSets = new HttpCookie("user_login");

                userSets.Value = login;
                userSets.Expires = expiresTime.AddHours(2);

                HttpContext.Current.Response.Cookies.Add(userSets);

                Logger.SaveLog(LogTypes.Info, "AuthenticationHandler.Autorize", "User was successfully authorized");

                return true;
            }

            Logger.SaveLog(LogTypes.Error, "AuthenticationHandler.Autorize", "Failed authorization");
            
            return false;
        }

        public int CreateUser(UsersVM user)
        {
            var account = _usersRepo.SelectItemByEmail(user.Email);

            if (account == null)
            {
                Logger.SaveLog(LogTypes.Info, "AuthenticationHandler.CreateUser", "New user was successfully created");

                return _usersRepo.Add(user);
            }

            Logger.SaveLog(LogTypes.Error, "AuthenticationHandler.CreateUser", "Error creating user");

            return 0;
        }
        
        public int RestorePassword(string email)
        {
            var item = _usersRepo.GetItemByEmail(email);

            if (item != null)
            {
                Logger.SaveLog(LogTypes.Info, "AuthenticationHandler.RestorePassword", "Password was successfully restored");

                return item.Id;
            }

            Logger.SaveLog(LogTypes.Error, "AuthenticationHandler.RestorePassword", "Error restoring password");

            return 0;
        }

        public bool ChangePassword(int id, string password)
        {
            var user = _usersRepo.GetItem(id);

            if (user != null)
            {
                user.Password = password;

                Logger.SaveLog(LogTypes.Info, "AuthenticationHandler.ChangePassword", "Password was successfully changed");

                return _usersRepo.Set(user);
            }

            Logger.SaveLog(LogTypes.Error, "AuthenticationHandler.ChangePassword", "Error changing password");

            return false;
        }

        public int UpdateUser(UsersVM user)
        {
            throw new NotImplementedException();
        }

        public bool IsEmail(string email)
        {
            var account = _usersRepo.SelectItemByEmail(email);

            if (account != null)
            {
                Logger.SaveLog(LogTypes.Warning, "AuthenticationHandler.IsEmail", "Email already exist");

                return true;
            }

            return false;
        }

        public bool LogOut()
        {
            var session = new HttpCookie("session_time");
            var login = new HttpCookie("user_login");

            session.Value = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            session.Expires = DateTime.Now;

            login.Value = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            login.Expires = DateTime.Now;

            HttpContext.Current.Response.Cookies.Add(session);
            HttpContext.Current.Response.Cookies.Add(login);

            Logger.SaveLog(LogTypes.Info, "AuthenticationHandler.LogOut", "Log out");
            
            return true;
        }
    }
}
