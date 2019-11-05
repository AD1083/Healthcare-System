using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
    public class Patient
    {
        private Alarm patientAlarm;
        private List<Module> modules = new List<Module>(4);
        private bool sendAlert;
        private static int patientIDNumber = 1;

        //patient details - related to UI - from databases
        public int PatientID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Condition { get; private set; }
        public string DOB { get; private set; }

        public Alarm PatientAlarm { get { return patientAlarm; } } //this alarm will contain all messages from each module alarm 

        public Patient()
        {
            //record the patient ID each time Patient instantiated
            PatientID = patientIDNumber;
            patientIDNumber++;

            //method to fill other properties of patient from DB

            //add the patients modules
            modules.Add(new Module("Pulse Rate"));
            modules.Add(new Module("Breathing Rate"));
            modules.Add(new Module("Blood Pressure"));
            modules.Add(new Module("Temperature"));
        }

        public void AccessModules()
        {
            //timer should be stopped before this called

            patientAlarm = null;
            sendAlert = false;

            string moduleMessages = "";
            foreach (Module patientModule in modules)
            {
                Alarm moduleAlarm = patientModule.CheckPatientData();
                if (moduleAlarm.SendAlarm)
                {
                    moduleMessages += moduleAlarm.AlarmMessage + "\n";
                    sendAlert = true;
                }
            }

            patientAlarm = new Alarm(moduleMessages);

            if (sendAlert)
            {
                RaiseAlert();
            }
        }

        private void RaiseAlert()
        {
            //Output patient alarm
            //Console.WriteLine("!!!! ALERT !!!!");
            //Console.WriteLine($"from patient '{PatientNumber}' modules:");
            //Console.WriteLine(alertMessage);
            //Console.Write("Press any key to rectify...");
            //Console.ReadKey();

            //EVENTS
            //show rectify button on PatientModuleView
            //display output of the patientAlarm - ie all the messages from each patient's module on their view
            //change indicator to red on central desk

            //centraldesk.showRectify
        }

        private void FillPatientProperties()
        {
            //access DB 

            //enter in the property data
        }

    }
}
