using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;


namespace Healthcare_System
{

    class DatabaseConnection
    {
        //the SQLConnection object used to store the connection to the database
        private SqlConnection sqlconn;
        private SqlDataAdapter sqlAdapter;

        //static attributes
        private static DatabaseConnection _instance;
        private static string dBConnectionString;

        public static DatabaseConnection Instance
        {
            get
            {
                // check if the object was created
                if (_instance == null)
                {
                    //create the object
                    _instance = new DatabaseConnection();

                    // set the connection string
                    dBConnectionString = Properties.Settings.Default.DBConnectionStr;

                }
                return _instance;
            }

        }

        //methods
        //create and return a data set
        public DataSet GetDataSet(string sqlStatement)
        {
            DataSet dsStaff = new DataSet();
            //open connenction to the DB
            OpenConnection();

            //create the table adapter using the connection string and the sql statement
            sqlAdapter = new SqlDataAdapter(sqlStatement, dBConnectionString);

            //fills in the data set using the data retrived using the SQL query into the dataset variable
            sqlAdapter.Fill(dsStaff);

            //close connection to the DB and return filled dataset
            CloseConnection();
            return dsStaff;
        }

        //open the connection
        private void OpenConnection()
        {
            //create the connection to the database as an instance of System.Data.SqlClient.SqlConnection 
            sqlconn = new System.Data.SqlClient.SqlConnection(dBConnectionString);
            //open the connection
            sqlconn.Open();
        }

        //close the connection
        private void CloseConnection()
        {
            //close the connection to the database
            sqlconn.Close();
        }
    }
}