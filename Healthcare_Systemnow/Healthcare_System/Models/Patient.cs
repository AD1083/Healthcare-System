﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Healthcare_System.Models
{
    public class Patient
    {
        private Alarm patientAlarm;
        private List<Module> modules = new List<Module>(4);
        private bool sendPatientAlarm;
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
            //reset local private variables so old state/data is no retained
            patientAlarm = null;
            sendPatientAlarm = false;

            string moduleMessages = ""; //to contain messages from any alarms from this patients modules

            //iterate through this patient's modules and determine if they have set an alarm
            foreach (Module patientModule in modules)
            {
                //check the patient data to see if an alarm is triggered
                Alarm moduleAlarm = patientModule.CheckPatientData();

                //if an alarm is set then record the alram message
                if (moduleAlarm.SendAlarm)
                {
                    moduleMessages += moduleAlarm.AlarmMessage + "\n";
                    //if at least one module has an alarm, then a patient has an alarm to send to the medical staff
                    sendPatientAlarm = true;
                }
            }

            //create a patient alarm which contains all the messages raised in module alarms
            patientAlarm = new Alarm(moduleMessages);

            //if an alarm needs to be sent for the patient, raise the alarm
            if (sendPatientAlarm)
            {
                RaiseAlert();
            }
        }

        private void RaiseAlert()
        {

            //EVENTS
            //show rectify button on PatientModuleView
            //display output of the patientAlarm - ie all the messages from each patient's module on their view
            //change indicator to red on central desk

            //centraldesk.showRectify
        }

        private void FillPatientProperties()
        {
            //access DB for Patient table, accessing the row which matches the patient ID
            DataSet patientDetails = DatabaseConnection.Instance.getDataSet($"SELECT * FROM Patient WHERE PatientID = {PatientID.ToString()}");

            //enter each row in the property data
            FirstName = patientDetails.Tables[0].Rows[0][1].ToString();
            LastName = patientDetails.Tables[0].Rows[0][2].ToString();
            DOB = patientDetails.Tables[0].Rows[0][3].ToString();
            Condition = patientDetails.Tables[0].Rows[0][5].ToString();
        }

    }
}
