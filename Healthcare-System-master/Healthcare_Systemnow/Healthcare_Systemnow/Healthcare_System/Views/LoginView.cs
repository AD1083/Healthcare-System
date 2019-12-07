using System;
using System.Windows.Forms;
using Healthcare_System.Views;

namespace Healthcare_System
{
    public partial class LoginView : Form, ILoginView
    {
        /// <summary>
        /// View event listeners set
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
            btnSignIn.Click += (sender, args) => Invoke(Login);//triggered on "Sign In" button click
        }

        //properties for staff details credentials
        public string StaffID { get { return txtStaff.Text; } }
        public string Password { get { return txtPassword.Text; } }
        public string Role { get; }

        //view event
        public event Action Login;

        private void Invoke(Action action)
        {
            if (action != null) action();
        }

        /// <summary>
        /// Close the application on "X" button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Show the view as a dialog
        /// </summary>
        public new void Show()
        {
            this.ShowDialog();
        }

        /// <summary>
        /// Show pop-up message
        /// </summary>
        /// <param name="message">message to be shown</param>
        public void ShowError(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// Solely UI method.
        /// When value entered into password textbox, set ispassword property to true
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {
            txtPassword.isPassword = true;
        }
    }
}


