using System;
using System.Windows.Forms;
using Healthcare_System.Views;

namespace Healthcare_System
{
    /// <summary>
    /// Windows forms inherting class that defines the events that occur and properties shown on the Managerial UI
    /// </summary>
    public partial class ManagerialView : Form, IManagerView
    {
        //event definitions for the interface
        public event EventHandler SignOut;
        public event EventHandler LoadData;

        //properties defined from the interface are given the set keyword so that UI elements can be set after data passed from the presenter
        public string StaffID { set { lblStaffID.Text = value; } }
        public string StaffName { set { lblStaffName.Text = value; } }
        public string StaffRole { set { lblStaffRole.Text = value; } }
        public string StartTime { set { lblStartTime.Text = value; } }
        public DataGridView DataGridRegistrations { get { return dataGridRegistrations; } }
        public DataGridView DataGridAlarms { get { return dataGridAlarms; } }

        /// <summary>
        /// constructor for the form
        /// initialises the form and defines the handlers for the events of: on load and sign out button click
        /// </summary>
        public ManagerialView()
        {
            InitializeComponent();
            btnSignOut.Click += BtnSignOut_Click;
            this.Load += ManagerialView_Load;
        }

        /// <summary>
        /// method to handle the event raised onload of the UI form
        /// </summary>
        /// <param name="sender">object that raised the event</param>
        /// <param name="e">arguments of the event</param>
        private void ManagerialView_Load(object sender, EventArgs e)
        {
            //if the LoadData event is not undefined then raise the event which calls to the Manager presenter
            if (LoadData != null) LoadData(this, EventArgs.Empty);
        }

        /// <summary>
        /// event handler for when the manager clicks the sign out button or X label on the UI
        /// </summary>
        /// <param name="sender">object that raised the event</param>
        /// <param name="e">arguments of the event</param>
        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            //if the SignOut event is not null then raise the sign out event to the presenter
            if (SignOut != null) SignOut(this, EventArgs.Empty);
        }

        /// <summary>
        /// this is the X close button on the UI
        /// will close the manager view, sign out the Manager who is logged in and return the UI to the login screen
        /// </summary>
        /// <param name="sender">object that raised the event</param>
        /// <param name="e">arguments of the event</param>
        private void label1_Click(object sender, EventArgs e)
        {
            BtnSignOut_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// event handler for events raised by the timer on the UI
        /// updates the current date and time to the UI
        /// </summary>
        /// <param name="sender">object that raised the event</param>
        /// <param name="e">arguments of the event</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.lblTime.Text = dateTime.ToString();
        }

        /// <summary>
        /// method definition for interface Show method, shows the form to the user
        /// </summary>
        public new void Show()
        {
            this.ShowDialog();
        }

    }
}
