using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace app.ViewModel
{
    public class UsersVM
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "This field is optional")]
        public string FName { set; get; }

        [Required(ErrorMessage = "This field is optional")]
        public string LName { set; get; }

        public string MName { set; get; }

        public Nullable<System.DateTime> BDay { set; get; }

        public Nullable<bool> Gender { set; get; }

        [Required(ErrorMessage = "This field is optional")]
        [RegularExpression(@"^(\+[0-9]{9})$", ErrorMessage = "Invalid number phone")]
        public string Phone { set; get; }

        [Required(ErrorMessage = "This field is optional")]
        [RegularExpression(@"(?i)\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", ErrorMessage = "Invalid e-mail address")]
        public string Email { set; get; }

        [Required(ErrorMessage = "This field is optional")]
        //[RegularExpression((@"^[^\s]{6,}$)(?=.*\d)(?=.*[a - zA - Z]"), ErrorMessage = "Invalid password")]
        public string Password { set; get; }

        public Nullable<int> TwitterId { set; get; }

        public DateTime Created { set; get; }
    }
}