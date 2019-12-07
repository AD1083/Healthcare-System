using System;
using System.Windows.Forms;

namespace Healthcare_System.Views
{
    /// <summary>
    /// interface for the manger view to be inherited by the presenter and view
    ///all events and properties outliined here must be defined by the inherited classes
    /// </summary>
    public interface IManagerView
    {
        //button click events
        event EventHandler SignOut;
        event EventHandler LoadData;
        //methods for UI action
        void Show();
        void Hide();
        //properties used by to display manager information on the UI, as set by the presenter
        string StaffID { set; } 
        string StaffRole { set; }
        string StaffName { set; }
        string StartTime { set; }
        //properties for the database output from the presente to the UI
        DataGridView DataGridRegistrations { get;  }
        DataGridView DataGridAlarms { get;  }
    }
}
