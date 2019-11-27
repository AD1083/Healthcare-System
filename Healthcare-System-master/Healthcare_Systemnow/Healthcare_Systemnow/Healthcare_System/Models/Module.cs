

namespace Healthcare_System.Models
{
    public class Module
    {
        //private class fields
        private bool alarmRectified = true; //not using auto property as default needs to be true to begin with
        //currentReadingInt keeps track of the current value in integer form, as current reading property is a string that can contain the message 'No Data Available'
        private int currentReadingInt = 0; 

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
                AlarmRectified = true; //no need to rectify
            }
            else if (UpperBoundary < 0 || LowerBoundary < 0)
            {
                //will cause the patient in CD to appear red must therefore change back upon boundaries being set
                ModuleAlarm = new Alarm($"Attention: {ModuleName}'s boundaries cannot be below zero!", false);
                AlarmRectified = true; //no need to rectify
            }
            else if (!(UpperBoundary == 0 || LowerBoundary == 0))
            {
                //generate reading data and record in the property
                int reading = GenerateReading();
                currentReadingInt = reading;
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
                    AlarmRectified = false; //must be seen to by the staff
                }
                else
                {
                    ModuleAlarm = new Alarm(); //return a blank alarm with no message, will cause no reaction for user and ui
                    AlarmRectified = true; //no need to rectify
                }
            }
            else
            {
                //will cause the patient in CD to appear red must therefore change back upon boundaries being set
                ModuleAlarm = new Alarm($"Attention: {ModuleName}'s boundaries not set!", false);
                AlarmRectified = true; //no need to rectify
            }
        }

        /// <summary>
        /// creates a 'reading' from the patients virtual bedside monitor
        /// </summary>
        /// <returns>integer reading for the module</returns>
        private int GenerateReading()
        {
            //set the boundaries of the singleton random class
            ConsistentRandom.Instance.UpperBoundary = UpperBoundary;
            ConsistentRandom.Instance.LowerBoundary = LowerBoundary;
            //result will be the return of the static GenerateValue method, which is passed the current value of the module
            //the current value is used to generate a value within reasonable range of the current
            return ConsistentRandom.Instance.GenerateValue(currentReadingInt);
        }

        /// <summary>
        /// comapres the module reading to the upper boundary
        /// </summary>
        /// <param name="reading">the integer reading of the module</param>
        /// <returns>boolean inidcating if the reading is outside or matches the upper boundary</returns>
        private bool CompareToUpperBoundary(int reading)
        {
            if (reading >= UpperBoundary) //emergency, pateint module reading above the upper boundary
            {
                return true;
            }
            return false; //patient module reading in normal range
        }

        /// <summary>
        /// comapres the module reading to the lower boundary
        /// </summary>
        /// <param name="reading">the integer reading of the module</param>
        /// <returns>boolean inidcating if the reading is outside or matches the lower boundary</returns>
        private bool CompareToLowerBoundary(int reading)
        {
            if (reading <= LowerBoundary) //emergency, pateint module reading below the lower boundary
            {
                return true;
            }
            return false; //patient module reading in normal range
        }
    }
}
