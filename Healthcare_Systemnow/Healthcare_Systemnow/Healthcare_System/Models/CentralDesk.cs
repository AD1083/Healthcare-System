using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Healthcare_System.Models
{
    public class CentralDesk
    {
        //list of all patients in the central desk bay, private as operated on only in this class, but object accesible through the property
        private static List<Patient> patients = new List<Patient>(8);

        //one overall timer to be used to avoid timer threading issues
        public static Timer patientTimer = new Timer();
        //property of the list of patients in the bay, publicly-accessbible for the presenters
        public List<Patient> Patients { get { return patients; } }

        /// <summary>
        /// constructor for a central desk that is used to create the pateints in the bay and setup the class timer
        /// </summary>
        public CentralDesk()
        {
            //create patients to the capacity of the bay - which is eight
            for (int i = 0; i < patients.Capacity; i++)
            {
                //create the patients and add them to the central desk list
                Patient patient = new Patient();
                patients.Add(patient);
            }
            //setup the timer used to read data from each patient's bedside modules
            SetupTimer();
        }

        /// <summary>
        /// public mthod for stopping the backen patient timer
        /// public to allow the timer to be stopped when the central desk is closed in the view
        /// </summary>
        public void DisableTimer()
        {
            patientTimer.Stop();
        }

        //OLD
        //public void RestartTime() //used for when timer only restarts when all patients recified
        //{
        //    bool restartTimer = false;

        //    //check if each patient's alarm has been rectified
        //    foreach(Patient patient in patients)
        //    {
        //        restartTimer = patient.AlarmRectified;
        //        if (patient.AlarmRectified)
        //        {
        //            patient.AlarmRectified = true; //CHECK if works since set {} has no external value - should inverse the sendPatientAlarm private field
        //        }
        //    }

        //    //only if all patient's alarms rectified should the timer start again
        //    if (restartTimer)
        //    {
        //        patientTimer.Start();
        //    }
        //}

        /// <summary>
        /// private method to setup and initialise the timer
        /// </summary>
        private void SetupTimer()
        {
            patientTimer.Interval = 1000; //event-raising interval
            patientTimer.AutoReset = true; //allows multple events to be raised
            patientTimer.Elapsed += ReadCheckModuleData; //method call on generation of the elapsed event
            patientTimer.Start(); //starting the timer
        }

        /// <summary>
        /// Elapsed event handler for events raised by the timer, parameters are auto-genrated by the timer event
        /// </summary>
        /// <param name="sender">the timer iobject which raised the event</param>
        /// <param name="e">contains data about the elapsed event</param>
        private void ReadCheckModuleData(object sender, ElapsedEventArgs e)
        {
            //stop the timer to prevent events occuring whilst accessing each patient's data
            DisableTimer();

            //go through each patient and each patients modules
            //call on patient to access its 4 modules to 'read' their monitoring data
            foreach (Patient patient in patients)
            {
                patient.AccessModules();
            }

            //restart the timer
            patientTimer.Start();
        }

        //OLD
        //private void ReadCheckModuleData(object sender, ElapsedEventArgs e)
        //{
        //    patientTimer.Stop();

        //    //go through each patient and each patients modules
        //    //call on patient to access its 4 modules to 'read' their monitoring data
        //    foreach (Patient patient in patients)
        //    {
        //        patient.AccessModules();
        //    }

        //    //timer can only restart after every patient alarm rectified
        //}
    }
}
