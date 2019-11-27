﻿using System.Data;


namespace Healthcare_System.Models
{
    public class ManagerialService
    {
        /// <summary>
        /// Retrieve all staff Registration records from the database
        /// </summary>
        /// <returns>DataTable holding staff system registration records</returns>
        public DataTable GetRegistrations()
        {
            DataTable dataTable = DatabaseConnection.Instance.GetDataSet("SELECT * FROM Registrations").Tables[0];
            return dataTable;
        }

        /// <summary>
        /// Retrieve all Alarms records from the database
        /// </summary>
        /// <returns>DataTable holding alarm data records</returns>
        public DataTable GetAlarms()
        {
            DataTable dataTable = DatabaseConnection.Instance.GetDataSet("SELECT * FROM Alarms").Tables[0];
            return dataTable;
        }
    }
}
