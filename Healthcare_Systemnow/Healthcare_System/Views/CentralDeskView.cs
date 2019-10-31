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
    public partial class CentralDeskView : Form, ICentralDeskView
    {
        public CentralDeskView()
        {
            InitializeComponent();
            //this.Load += CentralDeskView_Load;
        }
        public event EventHandler SignOut;
        public event EventHandler ViewPatient;
        


        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      


        //public event EventHandler StartPatientSimulation;
        //private void CentralDeskView_Load(object sender, EventArgs e)
        //{
        //    if (StartPatientSimulation != null) StartPatientSimulation(this, EventArgs.Empty);
        //}

        //public new void Show()
        //{
        //    this.ShowDialog();
        //}
    }
}
