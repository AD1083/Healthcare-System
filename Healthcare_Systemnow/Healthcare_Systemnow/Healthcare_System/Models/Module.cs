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
        private bool alarmRectified = true;

        //boundaries to be set by the PateintModuleViewPresenter when staff enter module boundaries on UI
        //get to allow displaying on the UI, set to allow PMVP to access this property
        public int UpperBoundary { get; set; }
        public int LowerBoundary { get; set; }

        //get to be accessed for UI display, but set in this class only by the reading generation/alarm creation
        public string CurrentReading { get; private set; }
        public string ModuleName { get; } //doesn't need a set as value can be set in constructor
        public Alarm ModuleAlarm { get; private set; }
       
        public bool AlarmRectified { get { return alarmRectified; } set { alarmRectified = value; } }

        /// <summary>
        /// constructor to create the patient's bedside moudles
        /// </summary>
        /// <param name="moduleName"></param>
        public Module(string moduleName)
        {
            ModuleName = moduleName;
            CurrentReading = "No Data Available";
        }

        /// <summary>
        /// generates a reading from the 
        /// </summary>
        public void CheckPatientData()
        {
            //ensure boundaries are set before creating a reading
            if (!(UpperBoundary == 0 || LowerBoundary == 0))
            {
                //generate reading data and record in the property
                int reading = GenerateReading();
                CurrentReading = reading.ToString();

                //compare to boundaries and return appropriate alarm
                if (CompareToUpperBoundary(reading)) //check for value above upper boundary
                {
                    ModuleAlarm = new Alarm($"Reading above {ModuleName} upper boundary!", true);
                    AlarmRectified = false;
                }

                else if (CompareToLowerBoundary(reading)) //check for value below lower boundary
                {
                    ModuleAlarm = new Alarm($"Reading below {ModuleName} lower boundary!", true);
                    AlarmRectified = false;
                }
                else
                {
                    ModuleAlarm = new Alarm(); //return a blank alarm with no message, will cause no reaction for user and ui
                    AlarmRectified = true;
                }
            }
            else
            {
                //will cause the patient in CD to appear red must therefore change back upon boundaries being set
                ModuleAlarm = new Alarm($"Attention: {ModuleName}'s boundaries not set!", false);
                AlarmRectified = true;
            }
        }

        ////OLD
        //public Alarm CheckPatientData()
        //{
        //    //ensure boundaries are set before creating a reading
        //    if (!(UpperBoundary == 0 || LowerBoundary == 0))
        //    {
        //        //generate reading data and record in the property
        //        int reading = GenerateReading();
        //        CurrentReading = reading.ToString();


        //        //compare to boundaries and return appropriate alarm
        //        if (CompareToUpperBoundary(reading)) //check for value above upper boundary
        //        {
        //            return new Alarm($"Reading above {ModuleName} upper boundary!");
        //        }

        //        if (CompareToLowerBoundary(reading)) //check for value below lower boundary
        //        {
        //            return new Alarm($"Reading below {ModuleName} lower boundary!");
        //        }

        //        return new Alarm(); //return a blank alarm with no message, will cause no reaction for uer and ui
        //    }

        //    //will cause the patient in CD to appear red must therefore change back upon boundaries being set
        //    return new Alarm($"Attention: {ModuleName}'s boundaries not set!");
        //}

        /// <summary>
        /// creates a 'reading' from the patients virtual bedside monitor
        /// </summary>
        /// <returns>interger reading for the module</returns>
        private int GenerateReading()
        {
            //create a random reading; extends the boundary for generating values by 10
            int reading = GeneratePatientData.Next(LowerBoundary - 10, UpperBoundary + 11); //Random.Next(inclusive, exclusive)
            //return the result
            return reading;
        }

        /// <summary>
        /// comapres the module reading to the upper boundary
        /// </summary>
        /// <param name="reading">the integer reading of the module</param>
        /// <returns>boolean inidcating if the reading is outside or matches the upper boundary</returns>
        private bool CompareToUpperBoundary(int reading)
        {
            if (reading >= UpperBoundary)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// comapres the module reading to the lower boundary
        /// </summary>
        /// <param name="reading">the integer reading of the module</param>
        /// <returns>boolean inidcating if the reading is outside or matches the lower boundary</returns>
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
