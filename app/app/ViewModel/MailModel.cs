using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app.ViewModel
{
    public class MailModel
    {
        public string From { set; get; }

        public string To { set; get; }

        public string Subject { set; get; }

        public string Body { set; get; }

        public bool IsHtml { set; get; }
    }
}