using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using RazorEngine;
using AJNewton.Models;

namespace AJNewton.Code
{
    public class Mail
    {
        public string recipient { 
            get { return ConfigurationManager.AppSettings["ContactEmailRecipient"]; }
        }

        public bool SendGeneric(ContactModel contactDetails)
        {
            contactDetails.message = contactDetails.message.Replace("\n", "<br />");
            System.Net.Mail.MailMessage m = this.BuildMessage(contactDetails, recipient);

            if (!string.IsNullOrWhiteSpace(recipient))
            {
                if (this.SendGeneric(m))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool SendGeneric(System.Net.Mail.MailMessage m)
        {
            try
            {
                System.Net.Mail.SmtpClient oSmtp = new System.Net.Mail.SmtpClient();
                oSmtp.EnableSsl = true;
                oSmtp.Send(m);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private System.Net.Mail.MailMessage BuildMessage(ContactModel contactDetails, string recipient)
        {

            string template = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/Views/Shared/ContactMail.cshtml"));
            string s = Razor.Parse(template, contactDetails);

            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(contactDetails.email, recipient);
            m.From = new System.Net.Mail.MailAddress(contactDetails.email, contactDetails.name);
            m.IsBodyHtml = true;
            m.Subject = "AJ Newton Customer Contact";
            m.Body = s;

            return m;
        }
    }
}