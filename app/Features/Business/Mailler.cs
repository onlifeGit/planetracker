using Features.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Features.Business
{
    public class Mailler
    {
        public bool Send(string to, string from, string body, bool isHtml = false, string subject = "")
        {
            MailMessage mail = new MailMessage(from, to, subject, body);
            mail.IsBodyHtml = isHtml;

            return Sender(mail);
        }

        private bool Sender(MailMessage mail)
        {
            try
            {
                string login = "";
                string pass = "";
                string host = "";
                bool ssl = false;
                int port = 25;

                SmtpClient smtp = new SmtpClient(host, port);
                smtp.Credentials = new NetworkCredential(login, pass);
                smtp.EnableSsl = ssl;

                smtp.Send(mail);

                //Logger.SaveLog(LogTypes.Info, "Mailler.Sender", "Letter was successfully sent");

                return true;
            }
            catch (Exception e)
            {
                //Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", "Failed sending letter");

                return false;
            }
        }
    }
}