using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
    public class Staff
    {
        private Registration _registration;
        public Registration Registration 
        { 
            get { return _registration; }
            set { _registration = value; }
        }
        public string StaffID { get; set; }
        public string Password { get; set; }
        public string FirstName {get; set;}
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}
