using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Views
{
    public interface IManagerView
    {
        event EventHandler SignOut;
        event EventHandler LoadData;
        void Show();
        void Hide();
        string StaffID { set; }
        string StaffRole { set; }
        string StaffName { set; }
        string StartTime { set; }
        DataGridView DataGridRegistrations { get;  }
        DataGridView DataGridAlarms { get;  }
    }
}
