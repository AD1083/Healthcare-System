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

        //to be set by the PMV when that accessed and got 
        public int UpperBoundary { get; set; }
        public int LowerBoundary { get; set; }
        public string CurrentReading { get; private set; }

        public string ModuleName { get; } // set; }

        public Module(string moduleName)
        {
            ModuleName = moduleName;
            CurrentReading = "No Data Available";
            //set boundaries?
        }

        public Alarm CheckPatientData()
        {

            //ensure boundaries are set before creating a reading
            if (!(UpperBoundary == 0 || LowerBoundary == 0))
            {
                //generate reading data and record in the property
                int reading = GenerateReading();
                CurrentReading = reading.ToString() ;
                
                //compare to boundaries and return appropriate alarm
                if (CompareToUpperBoundary(reading))
                {
                    return new Alarm($"Reading above {ModuleName} upper boundary!");
                }

                if (CompareToLowerBoundary(reading))
                {
                    return new Alarm($"Reading below {ModuleName} lower boundary!");
                }

                return new Alarm(); //return a blank alarm with no message, will cause no reaction for ui
            }

            //will cause the patient in CD to appear red must therefore change back upon boundaries being set
            return new Alarm($"Attention: {ModuleName}'s boundaries not set!");
        }

        private int GenerateReading()
        {
            //create a random reading
            int reading = GeneratePatientData.Next(LowerBoundary - 10, UpperBoundary + 11);
            //return the result
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
