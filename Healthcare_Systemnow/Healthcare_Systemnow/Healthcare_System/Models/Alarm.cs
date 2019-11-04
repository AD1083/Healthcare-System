using Healthcare_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public class Alarm
    {
        public bool AlarmStatus { get; set; }

        public Module Module { get; set; }
        public string StaffID { get; set; }
        public string AlarmMessage { get; }
        public bool SendAlarm { get; set; }
        public DateTime AlarmStartTime { get; }

        public Alarm()
        {
            SendAlarm = false;
        }

        public Alarm(string alarmMessage)
        {
            AlarmMessage = alarmMessage;
            AlarmStartTime = DateTime.UtcNow;
            SendAlarm = true;
        }
    }
}
