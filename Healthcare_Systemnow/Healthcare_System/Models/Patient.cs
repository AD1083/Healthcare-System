using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
    class Patient
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Condition { get; set; }
        public string PatientNumber { get; set; }
        public List <Module> Modules { get; set; }
    }
}
