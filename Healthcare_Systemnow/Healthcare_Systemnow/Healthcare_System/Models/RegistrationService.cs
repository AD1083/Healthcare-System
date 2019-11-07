using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
    public class RegistrationService
    {
        public void RecordStartTime(Staff staff)
        {
            staff.Registration = new Registration();
            staff.Registration.StartTime = DateTime.Now.ToString();
            staff.Registration.StaffID = staff.StaffID;
            //Record these to the Databse
        }
        public void RecordEndTime(Staff staff)
        {
            staff.Registration.EndTime = DateTime.Now.ToString();
            int staffID;
            Int32.TryParse(staff.Registration.StaffID, out staffID);
            //record end time to the database
            DatabaseConnection.Instance.InsertData($"INSERT INTO Registrations (StaffID, RegistrationTime, DeregistrationTime) " +
               $"VALUES ({staffID}, '{staff.Registration.StartTime}', '{staff.Registration.EndTime}')");
        }
    }
}
