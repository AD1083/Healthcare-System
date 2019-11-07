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
        private static List<Patient> patients = new List<Patient>(8);

        //one overall timer to be used to avoid timer threading issues
        public static Timer patientTimer = new Timer();

        public List<Patient> Patients { get { return patients; } }

        public CentralDesk()
        {
            for (int i = 0; i < patients.Capacity; i++)
            {
                //create the patients
                Patient patient = new Patient();
                patients.Add(patient);
            }

            SetupTimer(); 
            //possible change timer logic so that stuff still generated even if others have not been setup
            //timer stops, goes through each patient etc,
            //if patient has an alarm it does not generate anymore values
            //other patients without alarm can continue to generate values
        }

        public void RestartTime() //used for when timer only restarts when all patients recified
        {
            bool restartTimer = false;

            //check if each patient's alarm has been rectified
            foreach(Patient patient in patients)
            {
                restartTimer = patient.AlarmRectified;
                if (patient.AlarmRectified)
                {
                    patient.AlarmRectified = true; //CHECK if works since set {} has no external value - should inverse the sendPatientAlarm private field
                }
            }

            //only if all patient's alarms rectified should the timer start again
            if (restartTimer)
            {
                patientTimer.Start();
            }
        }

        private void SetupTimer()
        {
            patientTimer.Interval = 1000;
            patientTimer.AutoReset = true;
            patientTimer.Elapsed += ReadCheckModuleData;
            patientTimer.Start();
        }

        private void ReadCheckModuleData(object sender, ElapsedEventArgs e)
        {
            patientTimer.Stop();

            //go through each patient and each patients modules
            //call on patient to access its 4 modules to 'read' their monitoring data
            foreach (Patient patient in patients)
            {
                patient.AccessModules();
            }

            //timer can only restart after every patient alarm rectified
        }
    }
}
