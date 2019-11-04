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
        private static DatabaseConnection _instance;
        private static string dBConnectionString;
        //the SQLConnection object used to store the connection to the database
        private System.Data.SqlClient.SqlConnection sqlconn;
        private System.Data.SqlClient.SqlDataAdapter sqlAdapter;
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
                    DatabaseConnection.DBConnectionString = Properties.Settings.Default.DBConnectionStr;

                }
                return _instance;
            }

        }
        //property for the connection string
        // to be used JUST in this class
        public static string DBConnectionString
        {
            set
            {
                dBConnectionString = value;
            }
        }

        //methods
        //open the connection
        public void openConnection()
        {
            //create the connection to the database as an instance of System.Data.SqlClient.SqlConnection 
            sqlconn = new System.Data.SqlClient.SqlConnection(dBConnectionString);
            //open the connection
            sqlconn.Open();

        }
        // Close the connection
        public void closeConnection()
        {
            //close the connection to the database
            sqlconn.Close();
        }
        // create and return a data set
        public DataSet getDataSet(string sqlStatement)
        {
            DataSet dsStaff= new DataSet();
            //open conn
            openConnection();

            //create the table adapter using the connection string and the sql statement
            sqlAdapter = new SqlDataAdapter(sqlStatement, dBConnectionString);

            //fills in the data set
            sqlAdapter.Fill(dsStaff);

            //close conn
            closeConnection();
            return dsStaff;

        }
    }
}