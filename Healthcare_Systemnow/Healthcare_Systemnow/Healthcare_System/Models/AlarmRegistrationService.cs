using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
    public class AlarmRegistrationService
    {
        public void RegisterAlarmData(Staff staff, Alarm alarm)
        {
            alarm.AlarmEndTime = DateTime.UtcNow.ToString();
            Int32.TryParse(staff.StaffID, out int staffID);
            DatabaseConnection.Instance.InsertData($"INSERT INTO Alarms (StaffID, Alarm_StartTime, Alarm_EndTime) " +
               $"VALUES ({staffID}, '{alarm.AlarmStartTime}', '{alarm.AlarmEndTime}')");
        }
    }
}
