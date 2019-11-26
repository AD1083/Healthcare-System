using Healthcare_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
    public class Alarm
    {
        //properties of an alarm
        public string AlarmMessage { get; }
        public bool SendAlarm { get; }
        public string AlarmStartTime { get; }
        public string AlarmEndTime { get; set; }

        /// <summary>
        /// constructor for a blank/false alarm
        /// sets the SendAlarm property to false, as no alram needs to be raised
        /// </summary>
        public Alarm()
        {
            SendAlarm = false;
        }

        /// <summary>
        /// constructor for a true emergency alarm,
        /// sets the AlarmMessage property using the parameter
        /// sets the AlarmStartTime to the current date and time
        /// sets the SendAlarm property to true
        /// </summary>
        /// <param name="alarmMessage">the message from the module why the alarm was triggered</param>
        public Alarm(string alarmMessage, bool sendAlarm)
        {
            AlarmMessage = alarmMessage;
            AlarmStartTime = DateTime.UtcNow.ToString();
            SendAlarm = sendAlarm;
        }
    }
}
