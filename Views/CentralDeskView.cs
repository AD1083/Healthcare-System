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
            //this.Load += new EventHandler(this.CaptureStartTimeOnLoad);
            //this.Load += (sender, args) => Invoke(CaptureStartTimeOnLoad);
            this.Load += CentralDeskView_Load;

            logoutBtn.Click += LogoutBtn_Click;
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            endTimelbl.Text = DateTime.Now.ToString();
            EndTime = endTimelbl.Text;
            if (CaptureEndTimeOnLogoutClick != null) CaptureEndTimeOnLogoutClick(this, EventArgs.Empty);
        }

        public string StartTime
        {
            get { return startTimelbl.Text; }
            set { startTimelbl.Text = value; }
        }
        public string EndTime
        {
            get { return endTimelbl.Text; }
            set { endTimelbl.Text = value; }
        }
        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }
        private void CentralDeskView_Load(object sender, EventArgs e)
        {
            startTimelbl.Text = DateTime.Now.ToString();
            StartTime = startTimelbl.Text;
            if (CaptureStartTimeOnLoad != null) CaptureStartTimeOnLoad(this, EventArgs.Empty);
        }
        public event EventHandler CaptureStartTimeOnLoad;
        public event EventHandler CaptureEndTimeOnLogoutClick;
        private void Invoke(Action action)
        {
            if (action != null) action();
        }

        //public event EventHandler CaptureStartTime;
        //private void CaptureStartTimeOnLoad(object sender, EventArgs e)
        //{
        //    if(CaptureStartTime != null) CaptureStartTime(this, EventArgs.Empty);
        //}
    }
}
