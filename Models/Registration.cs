using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
       
    public class Registration
    {
        //properties of a regsitration object
        public string StaffID { get; set; } //staff id used for login
        public string StartTime { get; set; } //staff start time
        public string EndTime { get; set; } //staff end time
    }
}
