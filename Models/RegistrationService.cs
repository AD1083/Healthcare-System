using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
    public class RegistrationService
    {
        /// <summary>
        /// Record staff system regsitration start time
        /// </summary>
        /// <param name="staff">Staff object that contains the staff </param>
        public void RecordStartTime(Staff staff)
        {
            staff.Registration = new Registration();//create the staff registration object
            staff.Registration.StartTime = DateTime.UtcNow.ToString();//record current time into registration object property
            staff.Registration.StaffID = staff.StaffID;//record registration staffID property
        }
        /// <summary>
        /// Record staff system registration end time and insert the registration data into database
        /// </summary>
        /// <param name="staff">staff, who is being registered</param>
        public void RecordEndTime(Staff staff)
        {
            staff.Registration.EndTime = DateTime.UtcNow.ToString();
            
            Int32.TryParse(staff.Registration.StaffID, out int staffID);//convert StaffID into int
            //record to the database
            DatabaseConnection.Instance.InsertData($"INSERT INTO Registrations (StaffID, RegistrationTime, DeregistrationTime) " +
               $"VALUES ({staffID}, '{staff.Registration.StartTime}', '{staff.Registration.EndTime}')");
        }
    }
}
