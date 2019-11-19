using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;


namespace Healthcare_System.Models
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
            sqlconn = new SqlConnection(dBConnectionString);
            //open connenction to the DB
            OpenConnection(sqlconn);

            //create the table adapter using the connection string and the sql statement
            sqlAdapter = new SqlDataAdapter(sqlStatement, dBConnectionString);

            //fills in the data set using the data retrived using the SQL query into the dataset variable
            sqlAdapter.Fill(dsStaff);

            //close connection to the DB and return filled dataset
            CloseConnection(sqlconn);
            return dsStaff;
        }

        /// <summary>
        /// method to insert data into the database
        /// </summary>
        /// <param name="sqlStatement">The sql insert statement for the database</param>
        public void InsertData(string sqlStatement)
        {

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlStatement;

            sqlconn = new SqlConnection(dBConnectionString);
            sqlCommand.Connection = sqlconn;

            OpenConnection(sqlconn);

            sqlCommand.ExecuteNonQuery();
            CloseConnection(sqlconn);
        }

        //open the connection
        private void OpenConnection(SqlConnection sqlconnection)
        {
            //open the connection
            sqlconnection.Open();
        }

        //close the connection
        private void CloseConnection(SqlConnection sqlconnection)
        {
            //close the connection to the database
            sqlconnection.Close();
        }
    }
}