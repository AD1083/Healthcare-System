﻿using System;
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

        public static Timer PatientTimer = new Timer();

        public List<Patient> Patients { get { return patients; } }

        public CentralDesk()
        {
            for (int i = 0; i < patients.Count; i++)
            {
                //create the patients
                Patient patient = new Patient();
                patients.Add(patient);
            }

            SetupTimer(); //change timer logic so that stuff still generated even if others have not been setup
        }

        private void SetupTimer()
        {
            PatientTimer.Interval = 1000;
            PatientTimer.AutoReset = true;
            PatientTimer.Elapsed += ReadCheckModuleData;
            PatientTimer.Enabled = true;
            PatientTimer.Start();
        }

        private void ReadCheckModuleData(object sender, ElapsedEventArgs e)
        {
            PatientTimer.Stop();

            //go through each patient and each patients modules
            //call on patient to access its 4 modules to 'read' their monitoring data
            foreach (Patient patient in patients)
            {
                patient.AccessModules();

            }

            PatientTimer.Start();
        }
    }
}
