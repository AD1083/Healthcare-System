using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimerAndModuleRead
{
    class Program
    {
        private static List<Patient> patients = new List<Patient>(8);

        public static Timer PatientTimer = new Timer();

        public static bool run = true;

        static void Main(string[] args)
        {
            for (int i = 0; i < 1; i++)
            {
                //create the patients
                Patient ppp = new Patient();
                patients.Add(ppp);
            }

            PatientTimer.Interval = 1000;
            PatientTimer.AutoReset = true;
            PatientTimer.Elapsed += ReadCheckModuleData;
            PatientTimer.Enabled = true;
            PatientTimer.Start();

            while (run)
            {

            }

            Console.ReadKey();
        }

        private static void ReadCheckModuleData(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            PatientTimer.Stop();
            //go through each patient and each patients modules
            //call on patient to access its 4 modules to 'read' and display their monitoring data
            foreach (Patient p in patients)
            {
                p.AccessModules();

            }

            PatientTimer.Start();
        }
    }
}
