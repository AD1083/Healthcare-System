using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Healthcare_System.Models
{
    public class LoginService
    {
        private PasswordEncryption passwordEncryption;

        /// <summary>
        /// Checks if the staff exists in the database by searching the database for the staff ID and password
        /// </summary>
        /// <param name="staff">The staff object produced from the Login</param>
        /// <returns>True, if stafffID and the encrypted password exist in the database, false otherwise</returns>
        public bool Login(Staff staff)
        {
            passwordEncryption = new PasswordEncryption(staff.Password);
            string encryptedPassword = passwordEncryption.EncryptedPassword;
            DataSet dsStaff = DatabaseConnection.Instance.getDataSet("SELECT * FROM Staff WHERE StaffID = '" + staff.StaffID + "' AND Password = '" + encryptedPassword + "'");
            

            DataTable table = dsStaff.Tables[0];
            if (table.Rows.Count == 1)
            {
                staff.Role = dsStaff.Tables[0].Rows[0][6].ToString();
                staff.FirstName = dsStaff.Tables[0].Rows[0][2].ToString();
                staff.LastName = dsStaff.Tables[0].Rows[0][3].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
