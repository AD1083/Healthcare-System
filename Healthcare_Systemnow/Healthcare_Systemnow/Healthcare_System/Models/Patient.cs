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

        //used to determine if the patient has an alarm to send to the staff; true to send an alarm, false if not
        //also determines if an alarm has been rectified; through the property of AlarmRectified which returns the inverse of this boolean
        //therefore when patient alarm is true, alarm rectified is false; when patient alarm false, alarm rectified
        private bool sendPatientAlarm;


        //patient details - related to UI - from databases
        public int PatientID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Condition { get; private set; }
        public string DOB { get; private set; }

        public bool AlarmRectified { get { return !sendPatientAlarm; } set { ModuleRectified(); } }

        //property returns the patient alarm to the caller
        public Alarm PatientAlarm { get { return patientAlarm; } } //this alarm will contain all messages from each module alarm 
        public List<Module> Modules { get { return modules; } }


        public Patient(int patientNumber)
        {
            //record the patient ID each time Patient instantiated
            PatientID = patientNumber;

            //extracts the details about patients from the patient table in the DB
            FillPatientProperties();

            //add the patient's modules
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
                //check if the module's alarm has been rectified by the medical staff
                //if the patient has been seen to, then new data and alarms can be raised by this module
                if (patientModule.AlarmRectified)
                {
                    //check the patient data to see if an alarm is triggered
                    patientModule.CheckPatientData();
                }

                moduleMessages += patientModule.ModuleAlarm.AlarmMessage + "\n";

                //if an alarm is set then record the alarm message, includes any previous unrectified alarms
                if (patientModule.ModuleAlarm.SendAlarm)
                {
                    //if at least one module has an alarm, then a patient has an alarm to send to the medical staff
                    sendPatientAlarm = true;
                }
            }

            if (sendPatientAlarm)
            {
                //create a patient alarm which contains all the messages raised in module alarms
                patientAlarm = new Alarm(moduleMessages, true);
            }
            else
            {
                //create a patient alarm which contains all the messages raised in module alarms
                patientAlarm = new Alarm(moduleMessages, false);
            }
        }

        private void ModuleRectified()
        {
            foreach (Module patientModule in modules)
            {
                patientModule.AlarmRectified = true;
            }
        }

        private void FillPatientProperties()
        {
            //access DB for Patient table, accessing the row which matches the patient ID
            DataSet patientDetails = DatabaseConnection.Instance.GetDataSet($"SELECT * FROM Patient WHERE PatientID = {PatientID.ToString()}");

            if (patientDetails.Tables[0].Rows.Count == 1) //ensures that there is data in the dataset 
            {
                //enter each row in the property data
                FirstName = patientDetails.Tables[0].Rows[0][1].ToString();  //FirstName
                LastName = patientDetails.Tables[0].Rows[0][2].ToString();  //LastName
                DOB = patientDetails.Tables[0].Rows[0][3].ToString();   //DateOfBirth
                Condition = patientDetails.Tables[0].Rows[0][5].ToString(); //Condition
            }

        }

    }
}
