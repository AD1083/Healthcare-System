using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerAndModuleRead
{
    class Patient
    {

        private static int patientCounter = 1;
        private List<Module> modules = new List<Module>(4);
        private Alert patientAlert;
        private bool sendAlert = false;
        private string alertMessage;

        public int PatientNumber { get; private set; }


        public Patient()
        {
            PatientNumber = patientCounter;
            patientCounter++;

            modules.Add(new Module("Blood Pressure"));
            modules.Add(new Module("Pulse Rate"));
            modules.Add(new Module("Temperature"));
            modules.Add(new Module("Something Else"));
        }

        public void CreateModule()
        {
            
        }

        //public void AccessModules()
        //{
        //    bool alertRaised = false;
        //    foreach (Module m in modules)
        //    {
        //        patientAlert = m.CheckPatientData();

        //        if (patientAlert.SendAlert && !alertRaised)
        //        {
        //            //make only one alert trigger
        //            alertRaised = true;
        //            Program.PatientTimer.Stop();

        //            //Print alert
        //            Console.WriteLine("!!!!ALERT!!!!");
        //            Console.WriteLine($"from patient {PatientNumber}");
        //            Console.WriteLine($"CONDITION: {patientAlert.AlertMessage}");
        //            Console.WriteLine("Press any key to Rectify...");
        //            Console.ReadKey();
        //        }
        //    }
        //    Program.PatientTimer.Start();
        //}

        public void AccessModules()
        {
            
            foreach (Module m in modules)
            {
                patientAlert = m.CheckPatientData();
                if (patientAlert.SendAlert)
                {
                    alertMessage += patientAlert.AlertMessage + "\n";
                    sendAlert = true;
                }

            }
            if (sendAlert)
            {
                RaiseAlert();
            }

            alertMessage = "";
            sendAlert = false;
        }

        private void RaiseAlert()
        {
            Console.WriteLine("!!!! ALERT !!!!");
            Console.WriteLine($"from patient '{PatientNumber}' modules:");
            Console.WriteLine(alertMessage);
            Console.Write("Press any key to rectify...");
            Console.ReadKey();
        }
    }
}
