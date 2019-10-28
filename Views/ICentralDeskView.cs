using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Views
{
    public interface ICentralDeskView : IView
    {
       // string StaffID { set; }
        string StartTime { get; set; }
        string EndTime { get; set; }

        //event EventHandler StartPatioentSimulationOnLoad;
        //event 
        event EventHandler CaptureStartTimeOnLoad;
        event EventHandler CaptureEndTimeOnLogoutClick;
    }
}
