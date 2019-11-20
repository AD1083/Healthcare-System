using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare_System.Views;

namespace Healthcare_System
{
    public partial class ManagerialView : Form, IManagerView
    {
        public ManagerialView()
        {
            InitializeComponent();
            btnSignOut.Click += BtnSignOut_Click;
            this.Load += ManagerialView_Load;
        }

        private void ManagerialView_Load(object sender, EventArgs e)
        {
            if (LoadData != null) LoadData(this, EventArgs.Empty);
        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            if (SignOut != null) SignOut(this, EventArgs.Empty);
        }
        public event EventHandler SignOut;
        public event EventHandler LoadData;
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public new void Show()
        {
            this.ShowDialog();
        }

        public string StaffID { set { lblStaffID.Text = value; } }
        public string StaffName { set { lblStaffName.Text = value; } }
        public string StaffRole { set { lblStaffRole.Text = value; } }
        public string StartTime { set { lblStartTime.Text = value; } }
        public DataGridView DataGridRegistrations { get { return dataGridRegistrations; }  }
        public DataGridView DataGridAlarms { get { return dataGridAlarms; } }
    }
}
