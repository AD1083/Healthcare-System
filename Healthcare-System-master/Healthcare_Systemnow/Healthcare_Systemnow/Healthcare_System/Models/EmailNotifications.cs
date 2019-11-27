using System;
using System.Net.Mail;

namespace Healthcare_System.Models
{
    //https://docs.microsoft.com/en-us/dotnet/api/system.net.mail?view=netframework-4.8 System.Net.Mail namespace
    public class EmailNotifications
    {
        //https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient?view=netframework-4.8

        private static EmailNotifications instance;
        //create smtp client to handle sending emails
        private static SmtpClient smtpClient = new SmtpClient();

        //properties for an email
        public string EmailMessage { get; set; }
        public string ReceipientEmailAddress { private get; set; }

        //singleton design pattern
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

        /// <summary>
        /// Method to consrtct and send an email containing the emergency alarm notification for a patient
        /// </summary>
        /// <returns>boolean inidicating if the email has been sent</returns>
        public void SendEmailNotification()
        {
            if (!(EmailMessage == null || ReceipientEmailAddress == null)) //strings have initial value of null
            {
                ConfigureSMTPClient(); //sets up the smtp client to send the email

                //create the email using the MailMessage class = sets all email properties; inc. to/from email, priority, subject and body
                MailMessage email = new MailMessage();
                email.From = new MailAddress("notifications@angliahealthcare.com");
                email.To.Add(new MailAddress(ReceipientEmailAddress)); //have to add email to the collection structure
                email.Priority = MailPriority.High; //sets the email priority as high for the alarm
                email.Subject = "Emergency Alarm Notification";
                email.Body = EmailMessage;

                //attempt to send the email, within try catch incase of network disconnect
                try
                {
                    smtpClient.Send(email);
                }
                catch (Exception) { } //network disconnect exception

                //release resources consumed by these objects
                email.Dispose();
                smtpClient.Dispose();

                //reset the properties ready for new message
                EmailMessage = null;
                ReceipientEmailAddress = null;
            }
        }

        /// <summary>
        /// Method to configure the SMTP client to the secure smtp port 587
        /// </summary>
        private void ConfigureSMTPClient()
        {
            //configuration of smtp properties to use secure port and encrypted communication wih host server
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true; //secure socket layer
            smtpClient.Host = "smtp.angliahealthcare.com"; //the healthcare trust's email server
            smtpClient.Timeout = 100;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network; //uses the network to send the email
        }
    }
}