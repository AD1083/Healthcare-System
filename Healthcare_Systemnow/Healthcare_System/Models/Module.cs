using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Healthcare_System
{
    public class Module
    {
        public int UpperBoundary { get; set; }
        public int LowerBoundary { get; set; }
        public Random GeneratePatientData { get; set; }
        public Timer ReadData { get; set; }
        public string ModuleName { get; set; }
        public Alarm alarm { get; set; }
    }
}
