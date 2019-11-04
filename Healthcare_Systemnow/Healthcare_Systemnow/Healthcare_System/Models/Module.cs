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
        private readonly Random GeneratePatientData = new Random();

        public int UpperBoundary { get; set; }
        public int LowerBoundary { get; set; }

        public string ModuleName { get; } // set; }
        //public Alarm alarm { get; } // set; }

        public Module(string moduleName)
        {
            ModuleName = moduleName;

            //set boundaries?
        }

        public Alarm CheckPatientData()
        {
            //generate data
            int reading = GenerateReading();

            //EVENT to update this module's display on PatientModuleView
            



            //compare to boundaries
            if (CompareToUpperBoundary(reading))
            {
                return new Alarm($"Above {ModuleName} upper boundary");
            }

            if (CompareToLowerBoundary(reading))
            {
                return new Alarm($"Below {ModuleName} lower boundary");
            }

            return new Alarm();
        }

        private int GenerateReading()
        {
            //create a reading
            int reading = GeneratePatientData.Next(LowerBoundary - 10, UpperBoundary + 21);
           
            return reading;
        }

        private bool CompareToUpperBoundary(int reading)
        {
            if (reading >= UpperBoundary)
            {
                return true;
            }
            return false;
        }
        private bool CompareToLowerBoundary(int reading)
        {
            if (reading <= LowerBoundary)
            {
                return true;
            }
            return false;
        }
    }
}
