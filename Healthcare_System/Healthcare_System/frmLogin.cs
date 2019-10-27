using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Healthcare_System
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            populateGridView();
        }
        public void populateGridView()
        {
            //get the data set
            DataSet dsStaff = DatabaseConnection.Instance.getDataSet("SELECT * FROM Staff");

            DataTable table = dsStaff.Tables[0];

            dataGridView1.DataSource = table;
        }


        public void signIn()
        {
            DataSet dsStaff = DatabaseConnection.Instance.getDataSet("Select * from Staff Where StaffId = '" + txtStaff.Text.Trim() + "' and Password = '" + txtPassword.Text.Trim() + "'");
            DataTable table = dsStaff.Tables[0];
            if (table.Rows.Count == 1)
            {
                frmModuleView obj = new frmModuleView();
                // frmPatientMonitoring objFrmPatientMonitoring = new frmPatientMonitoring();
                this.Hide();
                obj.Show();
            }
            else
            {
                MessageBox.Show("Check your username and password");
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            signIn();
        }
    }
        }
    

