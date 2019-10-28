using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
    public class Registration
    {
        //private Staff _staff;
        //public Registration(Staff staff, string startTime)
        //{
        //    StartTime = startTime;
        //    _staff = staff;
           
        //}
        public string StaffID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
