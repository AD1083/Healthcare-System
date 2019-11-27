

namespace Healthcare_System.Models
{
    public class Staff
    {
        //Staff Properties, where staff info from the database are set
        public string StaffID { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string EmailAddress { get; set; }
        public Registration Registration { get; set; } 
    }
}
