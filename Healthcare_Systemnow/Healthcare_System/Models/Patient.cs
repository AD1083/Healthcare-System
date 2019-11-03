using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
    class Patient
    {
        private Alarm patientAlarm;
        private List<Module> modules = new List<Module>(4);
        private bool sendAlert;

        //patient details - related to UI - from databases
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Condition { get; set; }
        public string PatientNumber { get; set; }

        public Alarm PatientAlarm { get { return patientAlarm; } } //this alarm will contain all messages from each module alarm 

        public Patient()
        {
            patientAlarm = null;
            sendAlert = false;

            modules.Add(new Module("Pulse Rate"));
            modules.Add(new Module("Breathing Rate"));
            modules.Add(new Module("Blood Pressure"));
            modules.Add(new Module("Temperature"));
        }

        public void AccessModules()
        {
            //timer should be stopped before this called


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
        }

    }
}
