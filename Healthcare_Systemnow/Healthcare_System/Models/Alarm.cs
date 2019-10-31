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
    }
}
