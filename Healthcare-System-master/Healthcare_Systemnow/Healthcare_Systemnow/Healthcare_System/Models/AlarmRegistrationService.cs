using System;

namespace Healthcare_System.Models
{
    public class AlarmRegistrationService
    {
        /// <summary>
        /// Inserts a new alarm record into the database
        /// records the staff id who rectified the alarm, and the alarm start time
        /// called when the rectify button has been pressed
        /// </summary>
        /// <param name="staff">Staff obect who rectified the alarm</param>
        /// <param name="alarm">Alarm object that contains the start time</param>
        public void RegisterAlarmData(Staff staff, Alarm alarm)
        {
            //set the end time for the alarm
            alarm.AlarmEndTime = DateTime.UtcNow.ToString();

            //parse the staff id to an integer for the database
            Int32.TryParse(staff.StaffID, out int staffID);
            //access the database instance and pass the sql insert query
            DatabaseConnection.Instance.InsertData($"INSERT INTO Alarms (StaffID, Alarm_StartTime, Alarm_EndTime) " +
               $"VALUES ({staffID}, '{alarm.AlarmStartTime}', '{alarm.AlarmEndTime}')");
        }
    }
}
