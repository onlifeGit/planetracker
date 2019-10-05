using app.Models;
using app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.Extensions
{
    public static class Mapper
    {
        #region ToViewModel
        public static UsersVM ToViewModel(this Users model)
        {
            if (model != null)
            {
                return new UsersVM
                {
                    Id = model.Id,
                    FName = model.FName,
                    LName = model.LName,
                    MName = model.MName,
                    BDay = model.BDay,
                    Gender = model.Gender,
                    Email = model.Email,
                    Password = model.Password,
                    Phone = model.Phone,
                    TwitterId = model.TwitterId,
                    Created = model.Created
                };
            }

            return new UsersVM();
        }

        public static IEnumerable<UsersVM> ToViewModel(this IEnumerable<Users> model)
        {
            return model.Select(t => t.ToViewModel());
        }
        #endregion

        #region ToModel
        public static Users ToModel(this UsersVM model)
        {
            return new Users
            {
                Id = model.Id,
                FName = model.FName,
                LName = model.LName,
                MName = model.MName,
                BDay = model.BDay,
                Gender = model.Gender,
                Email = model.Email,
                Password = model.Password,
                Phone = model.Phone,
                TwitterId = model.TwitterId,
                Created = model.Created == DateTime.MinValue ?
                                                DateTime.Now : model.Created
            };
        }

        public static IEnumerable<Users> ToModel(this IEnumerable<UsersVM> model)
        {
            return model.Select(t => t.ToModel());
        }
        #endregion

    }
}