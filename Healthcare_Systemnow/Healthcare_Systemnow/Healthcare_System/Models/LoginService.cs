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

            //encrypt the user password before comparing to the db
            passwordEncryption = new PasswordEncryption(staff.Password);
            string encryptedPassword = passwordEncryption.EncryptedPassword;
            //convert staffID to integer value for the db
            Int32.TryParse(staff.StaffID, out int staffID);
            //run sql query to find a matching staff id and password in the database
            //uses singleton of Databsae Connection class
            DataSet dsStaff = DatabaseConnection.Instance.GetDataSet("SELECT * FROM Staff WHERE StaffID = '" + staffID + "' AND Password = '" + encryptedPassword + "'");

            //convert the db dataset to a table
            DataTable table = dsStaff.Tables[0];
            //if the table contains one row there is a matching staff id and password in the database
            //therefore login is succesful, so fill the staff properties with the details from the db table
            if (table.Rows.Count == 1)
            {
                staff.Role = dsStaff.Tables[0].Rows[0][6].ToString();
                staff.FirstName = dsStaff.Tables[0].Rows[0][2].ToString();
                staff.LastName = dsStaff.Tables[0].Rows[0][3].ToString();
                return true; //login succes
            }
            else //no row in table, so no matching staff in db
            {
                return false; //login failed
            }
        }
    }
}
