using app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using app.ViewModel;

namespace app.Business
{
    public class Mailler
    {
        public bool Send(string from, string to, string subject, string body, bool isHtml = false)
        {
            return Sender(from, to, subject, body, isHtml);
        }

        private bool Sender(string from, string to, string subject, string body, bool isHtml)
        {
            try
            {
                string host = "smtp.gmail.com";
                int port = 587;//OR 58

                string login = "planetrackerteam@gmail.com";
                string pass = "4lyW1thm3";
                
                bool ssl = true;
                

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = port;
                    smtp.Credentials = new NetworkCredential(login, pass);
                    smtp.EnableSsl = ssl;

                    smtp.Send(from, to, subject, body);
                }

                Logger.SaveLog(LogTypes.Info, "Mailler.Sender", "Letter was successfully sent");

                return true;
            }
            catch (Exception e)
            {
                Logger.SaveLog(LogTypes.Error, $"{e.Source}: {e.TargetSite}", "Failed sending letter");

                return false;
            }
        }
    }
}