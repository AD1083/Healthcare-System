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
    public partial class CentralDeskView : Form //, ICentralDeskView
    {

        public CentralDeskView()
        {
            InitializeComponent();
            this.Load += CentralDeskView_Load;
            btnSignOut.Click += BtnSignOut_Click;
            btnRoom1.Click += (sender, args) => Invoke(ViewPatient);
            btnRoom2.Click += (sender, args) => Invoke(ViewPatient);
        }
        //properties
        public string FirstNameRoom1 { get { return lblFirstnameRoom1.Text; } }
        public string LastnameRoom1 { get { return lblLastNameRoom1.Text; } }
        public string ConditionRoom1 { get { return lblConditionRoom1.Text; } }
        public string Room1 { get { return lblRoom1.Text; } }
        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            if(SignOut!=null) SignOut(this, EventArgs.Empty);
        }

        public event EventHandler SignOut;
        public event Action ViewPatient;

        private void Invoke(Action action)
        {
            if (action != null) action();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }




        public event EventHandler StartSimulation;
        private void CentralDeskView_Load(object sender, EventArgs e)
        {
            if (StartSimulation != null) StartSimulation(this, EventArgs.Empty);

        }

        public new void Show()
        {
            this.ShowDialog();
        }
    }
}
