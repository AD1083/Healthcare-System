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
    public partial class LoginView : Form, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
            btnSignIn.Click += (sender, args) => Invoke(Login);
        }

        public string StaffID { get { return txtStaff.Text; } }
        public string Password { get { return txtPassword.Text; } }
        public string Role { get; }
        public event Action Login;
        public void ShowError(string message)
        {
            MessageBox.Show(message);
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
            this.ShowDialog();
        }
       
        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            txtPassword.isPassword = true;
        }
    }
}


