using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Healthcare_System.Models
{
    public class LoginService : ILoginService
    {
        /// <summary>
        /// Checks if the staff exists in the database
        /// </summary>
        /// <param name="staff"></param>
        /// <returns>True, if stafffID and password exist in the database, false otherwise</returns>
        public bool Login(Staff staff)
        {
            DataSet dsStaff = DatabaseConnection.Instance.getDataSet("Select * from Staff Where StaffId = '" + staff.StaffID + "' and Password = '" + staff.Password + "'");
            DataTable table = dsStaff.Tables[0];
            if (table.Rows.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
