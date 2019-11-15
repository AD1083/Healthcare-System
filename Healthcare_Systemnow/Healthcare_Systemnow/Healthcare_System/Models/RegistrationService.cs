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
            staff.Registration.StartTime = DateTime.UtcNow.ToString();
            staff.Registration.StaffID = staff.StaffID;
            //Record these to the Databse
        }
        public void RecordEndTime(Staff staff)
        {
            staff.Registration.EndTime = DateTime.UtcNow.ToString();
            
            Int32.TryParse(staff.Registration.StaffID, out int staffID);
            //record end time to the database
            DatabaseConnection.Instance.InsertData($"INSERT INTO Registrations (StaffID, RegistrationTime, DeregistrationTime) " +
               $"VALUES ({staffID}, '{staff.Registration.StartTime}', '{staff.Registration.EndTime}')");
        }
    }
}
