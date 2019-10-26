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
        private readonly ApplicationContext _context;
        public CentralDeskView(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
        }

        public string StartTime
        {
            set { startTimetxtbox.Text = DateTime.Now.ToString(); }
        }
        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }
    }
}
