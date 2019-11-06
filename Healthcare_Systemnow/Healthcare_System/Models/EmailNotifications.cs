using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Healthcare_System.Models
{
    //https://docs.microsoft.com/en-us/dotnet/api/system.net.mail?view=netframework-4.8
    class EmailNotifications
    {
        //https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient?view=netframework-4.8

        private static EmailNotifications instance;
        private SmtpClient smtpClient;

        //properties for an email
        public string EmailMessage { private get; set; }
        public string ReceipientEmailAddress { private get; set; }

        public static EmailNotifications Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmailNotifications();
                }
                return instance;
            }
        }

        public void SendEmailNotification()
        {
            
        }

        private void ConfigureSMTPClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Host = "smtp.angliahealthcare.com";
            smtpClient.Timeout = 100;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        }
    }
}
