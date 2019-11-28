using System;
using System.Net.Mail;

namespace Healthcare_System.Models
{
    class Notifications
    {

        ////https://docs.microsoft.com/en-us/dotnet/api/system.net.mail?view=netframework-4.8 System.Net.Mail namespace
        //https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient?view=netframework-4.8

        private static Notifications instance;
        //create smtp client to handle sending emails
        private static SmtpClient smtpClient = new SmtpClient();

        //properties for an email
        public string Message { get; set; }
        public string ReceipientEmailAddress { private get; set; }
        public string ReceipientMobileNumber { private get; set; }

        //singleton design pattern
        public static Notifications Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Notifications();
                }
                return instance;
            }
        }

        /// <summary>
        /// Method to construct and send an email to a consultant containing the emergency alarm notification for a patient
        /// </summary>
        public void SendEmailNotification()
        {
            if (!(Message == null || ReceipientEmailAddress == null)) //strings have initial value of null
            {
                Email(ReceipientEmailAddress);
            }
        }

        /// <summary>
        /// Method to send a text message to a nurse wihch contains the emergency alarm notification of a patient
        /// </summary>
        public void SendTextNotification()
        {
            if (!(Message == null || ReceipientMobileNumber == null)) //cant sent a blank message
            {
                //passing the staff phone number concatenated with the email-to-text email address of the carrier

                /*in the code we assume that the staff memebers are provided with phones and have therefore chosen EE to be the carrier
                *this is due to not all UK phone carriers providing a public email-to-text email address, and not being able to differrntaite the
                *carrier using the mobile number. Some third-party applications exist such as the API at: https://www.twilio.com/.
                * However these cost money so have been researched rather than implemented
                */

                Email(ReceipientMobileNumber + "@mms.ee.co.uk"); 
            }
        }

        /// <summary>
        /// Method to safely send an email through the secure SMTP client
        /// </summary>
        /// <param name="emailAddress">The email address that will be used to send the alarm message to</param>
        private void Email(string emailAddress)
        {
            ConfigureSMTPClient(); //sets up the smtp client to send the email

            //create the email using the MailMessage class = sets all email properties; inc. to/from email, priority, subject and body
            MailMessage email = new MailMessage();
            email.From = new MailAddress("notifications@angliahealthcare.com");
            email.To.Add(new MailAddress(emailAddress)); //have to add email to the collection structure
            email.Priority = MailPriority.High; //sets the email priority as high for the alarm
            email.Subject = "Emergency Alarm Notification";
            email.Body = Message;

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
            Message = null;
            ReceipientEmailAddress = null;
            ReceipientMobileNumber = null;
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
