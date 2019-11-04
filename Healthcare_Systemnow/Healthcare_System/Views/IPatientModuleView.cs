using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public interface IPatientModuleView
    {
         
        event EventHandler RectifyAlarm;
        event EventHandler SetTheModules;
        event EventHandler TriggerAlarm;
        event EventHandler GoBack;
    }
}

