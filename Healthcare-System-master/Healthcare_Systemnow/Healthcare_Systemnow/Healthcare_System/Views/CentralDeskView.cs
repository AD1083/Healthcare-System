using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare_System.Views;

namespace Healthcare_System
{
    public partial class CentralDeskView : Form, ICentralDeskView
    {
        public CentralDeskView()
        {
            InitializeComponent();
            this.Load += CentralDeskView_Load;

            btnSignOut.Click += BtnSignOut_Click;
            btnRoom1.Click += (sender, args) => Invoke(ViewPatient1);
            btnRoom2.Click += (sender, args) => Invoke(ViewPatient2);
            btnRoom3.Click += (sender, args) => Invoke(ViewPatient3);
            btnRoom4.Click += (sender, args) => Invoke(ViewPatient4);
            btnRoom5.Click += (sender, args) => Invoke(ViewPatient5);
            btnRoom6.Click += (sender, args) => Invoke(ViewPatient6);
            btnRoom7.Click += (sender, args) => Invoke(ViewPatient7);
            btnRoom8.Click += (sender, args) => Invoke(ViewPatient8);

        }

        //properties

        public string StaffID { set { lblStaffID.Text = value; } }
        public string StaffName { set { lblStaffName.Text = value; } }
        public string StaffRole { set { lblStaffRole.Text = value; } }
        public string StartTime { set { lblStartTime.Text = value; } }

        public string FirstNameRoom1 { set { lblFirstNameRoom1.Text = value; } }
        public string LastNameRoom1 { set { lblSecondNameRoom1.Text = value; } }
        public string ConditionRoom1 { set { lblConditionRoom1.Text = value; } }
        public string Room1 { get { return lblRoom1.Text; } }

        public string FirstNameRoom2 { set { lblFirstNameRoom2.Text = value; } }
        public string LastNameRoom2 { set { lblSecondNameRoom2.Text = value; } }
        public string ConditionRoom2 { set { lblConditionRoom2.Text = value; } }
        public string Room2 { get { return lblRoom2.Text; } }

        public string FirstNameRoom3 { set { lblFirstNameRoom3.Text = value; } }
        public string LastNameRoom3 { set { lblSecondNameRoom3.Text = value; } }
        public string ConditionRoom3 { set { lblConditionRoom3.Text = value; } }
        public string Room3 { get { return lblRoom3.Text; } }

        public string FirstNameRoom4 { set { lblFirstNameRoom4.Text = value; } }
        public string LastNameRoom4 { set { lblSecondNameRoom4.Text = value; } }
        public string ConditionRoom4 { set { lblConditionRoom4.Text = value; } }
        public string Room4 { get { return lblRoom4.Text; } }

        public string FirstNameRoom5 { set { lblFirstNameRoom5.Text = value; } }
        public string LastNameRoom5 { set { lblSecondNameRoom5.Text = value; } }
        public string ConditionRoom5 { set { lblConditionRoom5.Text = value; } }
        public string Room5 { get { return lblRoom5.Text; } }

        public string FirstNameRoom6 { set { lblFirstNameRoom6.Text = value; } }
        public string LastNameRoom6 { set { lblSecondNameRoom6.Text = value; } }
        public string ConditionRoom6 { set { lblConditionRoom6.Text = value; } }
        public string Room6 { get { return lblRoom6.Text; } }

        public string FirstNameRoom7 { set { lblFirstNameRoom7.Text = value; } }
        public string LastNameRoom7 { set { lblSecondNameRoom7.Text = value; } }
        public string ConditionRoom7 { set { lblConditionRoom7.Text = value; } }
        public string Room7 { get { return lblRoom7.Text; } }

        public string FirstNameRoom8 { set { lblFirstNameRoom8.Text = value; } }
        public string LastNameRoom8 { set { lblSecondNameRoom8.Text = value; } }
        public string ConditionRoom8 { set { lblConditionRoom8.Text = value; } }
        public string Room8 { get { return lblRoom8.Text; } }


        public Panel PanelRoom1 { get { return pnl1; } set { pnl1 = value; } }
        public Panel PanelRoom2 { get { return pnl2; } set { pnl2 = value; } }
        public Panel PanelRoom3 { get { return pnl3; } set { pnl3 = value; } }
        public Panel PanelRoom4 { get { return pnl4; } set { pnl4 = value; } }
        public Panel PanelRoom5 { get { return pnl5; } set { pnl5 = value; } }
        public Panel PanelRoom6 { get { return pnl6; } set { pnl6 = value; } }
        public Panel PanelRoom7 { get { return pnl7; } set { pnl7 = value; } }
        public Panel PanelRoom8 { get { return pnl8; } set { pnl8 = value; } }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            if (SignOut != null) SignOut(this, EventArgs.Empty);
        }

        public event Action ViewPatient1;
        public event Action ViewPatient2;
        public event Action ViewPatient3;
        public event Action ViewPatient4;
        public event Action ViewPatient5;
        public event Action ViewPatient6;
        public event Action ViewPatient7;
        public event Action ViewPatient8;
        public event EventHandler StartSimulation;
        public event EventHandler SignOut;
        public event EventHandler ChangePanelColour;


        public new void Show()
        {
            this.ShowDialog();
        }


        private void Invoke(Action action)
        {
            if (action != null) action();
        }


        private void CentralDeskView_Load(object sender, EventArgs e)
        {
            if (StartSimulation != null) StartSimulation(this, EventArgs.Empty);

        }


        private void label1_Click(object sender, EventArgs e)
        {
            BtnSignOut_Click(this, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.lblTime.Text = dateTime.ToString();

            if (ChangePanelColour != null) ChangePanelColour(this, EventArgs.Empty);


        }
    }
}