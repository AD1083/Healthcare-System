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
using Healthcare_System.Views;

namespace Healthcare_System
{
    
    public partial class frmLogin : Form, ILoginView
    {
        private readonly ApplicationContext _context;
        public frmLogin(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            btnSignIn.Click += (sender, args) => Invoke(Login);
        }
        public string StaffID { get { return txtStaff.Text; } }
        public string Password { get { return txtPassword.Text; } }
        public event Action Login;
        public void ShowError()
        {
            MessageBox.Show("Check your username and password");
        }
        private void Invoke(Action action)
        {
            if (action != null) action();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        //public new void Show()
        //{
        //    Application.Run(this);
        //}

    }
}
    

