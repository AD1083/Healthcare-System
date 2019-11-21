using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Healthcare_System.Models
{
    public class Module
    {
        private readonly ConsistentRandom consistentRandom = new ConsistentRandom();
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
            //ensure boundaries are set to before creating a reading
            if (UpperBoundary < LowerBoundary)
            {

                ModuleAlarm = new Alarm($"Attention: {ModuleName}'s upper boundary cannot be less than the lower boundary!", false);
                AlarmRectified = true; //no need to have the non-emergency alarm be rectified
            }
            else if (LowerBoundary > UpperBoundary)
            {
                //will cause the patient in CD to appear red must therefore change back upon boundaries being set
                ModuleAlarm = new Alarm($"Attention: {ModuleName}'s lower boundary cannot be greater than the upper boundary!", false);
                AlarmRectified = true;
            }
            else if (UpperBoundary < 0 || LowerBoundary < 0)
            {
                //will cause the patient in CD to appear red must therefore change back upon boundaries being set
                ModuleAlarm = new Alarm($"Attention: {ModuleName}'s boundaries cannot be below zero!", false);
                AlarmRectified = true;
            }
            else if (!(UpperBoundary == 0 || LowerBoundary == 0))
            {
                //generate reading data and record in the property
                int reading = GenerateReading();
                CurrentReading = reading.ToString();

                //compare to boundaries and return appropriate alarm
                if (CompareToUpperBoundary(reading)) //check for value above upper boundary
                {
                    ModuleAlarm = new Alarm($"Reading above {ModuleName} upper boundary!", true);
                    AlarmRectified = false; //emergency alarm must be rectified
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
                ModuleAlarm = new Alarm($"Attention: {ModuleName}'s not set!", false);
                AlarmRectified = true;
            }
        }

        /// <summary>
        /// creates a 'reading' from the patients virtual bedside monitor
        /// </summary>
        /// <returns>interger reading for the module</returns>
        private int GenerateReading()
        {

            consistentRandom.UpperBoundary = UpperBoundary;
            consistentRandom.LowerBoundary = LowerBoundary;
            return consistentRandom.GenerateValue();
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
