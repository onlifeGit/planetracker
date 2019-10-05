using app.Repo;
using app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using app.Business;

namespace app.Controllers
{
    public class authenticationController : Controller
    {
        private UsersRepo _usersRepo = new UsersRepo();
        private AuthenticationHandler _authHandler = new AuthenticationHandler();

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string login, string password)
        {
            if (_authHandler.Autorize(login, password))
            {
                return RedirectToAction("index", "home");
            }

            ViewBag.Message = "Помилка! Спробуйте ще";
            return View();
        }

        public JsonResult registrate(UsersVM model)
        {
            if (_authHandler.CreateUser(model) != 0)
                return Json(Url.Action("login", "authentication"), JsonRequestBehavior.AllowGet);

            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult restorePassword(string email)
        {
            return Json(_usersRepo.GetItemByEmail(email), JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult isEmail(string email)
        {
            return Json(_authHandler.IsEmail(email), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult logOut()
        {
            _authHandler.LogOut();
            return RedirectToAction("login");
        }
    }
}