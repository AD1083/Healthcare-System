using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare_System.Views
{
    public partial class PatientModuleView : Form
    {
        public PatientModuleView()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
                Application.Exit();
           
        }
    }
}
