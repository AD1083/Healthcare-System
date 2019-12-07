using System;
using System.Collections.Generic;
using System.Linq;
using Healthcare_System.Models;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Healthcare_System
{
    class PatientModuleViewPresenter
    {

        private readonly Patient _patient;//patient object for the current view variation
        private readonly IPatientModuleView _view;//instance of the view interface to expose the actual view functionality
        private readonly CentralDesk _centralDesk;//backend  instance of cental desk logic
        private List<Module> patientModuleList;//list the current patient's modules
        private Alarm patientAlarm;//backend instance of alarm
        private AlarmRegistrationService _service;//backend service for registering alarms info
        private Staff _staff;//instance of staff signed in and viewing the patient

        /// <summary>
        /// Patient Module View presenter constructor, which is an interface between the frontend views and backend models
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="view"></param>
        /// <param name="centralDesk"></param>
        /// <param name="staff"></param>
        /// <param name="service"></param>
        public PatientModuleViewPresenter(Patient patient, IPatientModuleView view, CentralDesk centralDesk, Staff staff, AlarmRegistrationService service)
        {
            //object instances declared in the constructor method call, passed into the presenter fields declared above
            //allows the presenter to interface between the backend model and the front end UI view
            _patient = patient;
            _view = view;
            _centralDesk = centralDesk;
            _staff = staff;
            _service = service;
            patientModuleList = _centralDesk.Patients.ElementAt(_patient.PatientID - 1).Modules;//list of modules of current patient

            _view.LoadPatientData += () => LoadPatientData();//on form loads backend models data
            //event handlers for setting modules boundaries, view properties from textboxes passed as arguments
            _view.SetPulseRate += () => SetPulseRate(_view.LowerPulseRate, _view.UpperPulseRate);
            _view.SetBreathingRate += () => SetBreathingRate(_view.LowerBreathingRate, _view.UpperBreathingRate);
            _view.SetBloodPressure += () => SetBloodPressure(_view.LowerBloodPressure, _view.UpperBloodPressure);
            _view.SetTemperature += () => SetTemperature(_view.LowerTemperature, _view.UpperTemperature);
            _view.GoBack += GoBack;//button handler for returning back to CentralDeskView
            _view.UpdatePatientModuleData += UpdatePatientModuleData;//timer triggered event for updating patient data
            _view.RectifyAlarm += RectifyAlarm;//alarm rectification handler

        }

        /// <summary>
        /// Set view properties with backend models data
        /// </summary>
        private void LoadPatientData()
        {
            //patients data
            _view.FirstName = _patient.FirstName;
            _view.LastName = _patient.LastName;
            _view.DOB = _patient.DOB.Substring(0, 10);
            _view.Condition = _patient.Condition;
            _view.PictureBox.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Images", _patient.Image));

            //modules boundaries data
            _view.UpperPulseRate = patientModuleList.ElementAt(0).UpperBoundary.ToString();
            _view.UpperBreathingRate = patientModuleList.ElementAt(1).UpperBoundary.ToString();
            _view.UpperBloodPressure = patientModuleList.ElementAt(2).UpperBoundary.ToString();
            _view.UpperTemperature = patientModuleList.ElementAt(3).UpperBoundary.ToString();
            _view.LowerPulseRate = patientModuleList.ElementAt(0).LowerBoundary.ToString();
            _view.LowerBreathingRate = patientModuleList.ElementAt(1).LowerBoundary.ToString();
            _view.LowerBloodPressure = patientModuleList.ElementAt(2).LowerBoundary.ToString();
            _view.LowerTemperature = patientModuleList.ElementAt(3).LowerBoundary.ToString();
        }

        /// <summary>
        /// Parse user entered data and set it into backend module model upper and lower boundaries properties
        /// </summary>
        /// <param name="lowerBoundary">lower boundary</param>
        /// <param name="upperBoundary">upper boundary</param>
        /// <param name="modulePosition">position of a module in a list</param>
        private void SetBoundaries(string lowerBoundary, string upperBoundary, int modulePosition)
        {
            Int32.TryParse(lowerBoundary, out int lb);
            patientModuleList.ElementAt(modulePosition).LowerBoundary = lb;
            Int32.TryParse(upperBoundary, out int ub);
            patientModuleList.ElementAt(modulePosition).UpperBoundary = ub;
        }

        private void SetPulseRate(string lowerPulseRate, string upperPulseRate)
        {
            SetBoundaries(lowerPulseRate, upperPulseRate, 0);
        }

        private void SetBreathingRate(string lowerBreathingRate, string upperBreathingRate)
        {
            SetBoundaries(lowerBreathingRate, upperBreathingRate, 1);
        }
        private void SetBloodPressure(string lowerBloodPressure, string upperBloodPressure)
        {
            SetBoundaries(lowerBloodPressure, upperBloodPressure, 2);
        }
        private void SetTemperature(string lowerTemperature, string upperTemperature)
        {
            SetBoundaries(lowerTemperature, upperTemperature, 3);
        }

        /// <summary>
        /// Hide current view to show Central Desk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBack(object sender, EventArgs e)
        {
            //hide current view
            _view.Hide();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdatePatientModuleData(object sender, EventArgs e)
        {
            _view.StopTimer();//stop UI timer
            //set new values from backend models into the view properties
            _view.CurPulseRate = patientModuleList.ElementAt(0).CurrentReading.ToString();
            _view.CurBreathingRate = patientModuleList.ElementAt(1).CurrentReading.ToString();
            _view.CurBloodPressureRate = patientModuleList.ElementAt(2).CurrentReading.ToString();
            _view.CurTemperature = patientModuleList.ElementAt(3).CurrentReading.ToString();
            //get patient's alarm from backend models
            patientAlarm = _centralDesk.Patients.ElementAt(_patient.PatientID - 1).PatientAlarm;
            if (patientAlarm != null)//if alarm exists
            {
                _view.AlarmMessage = patientAlarm.AlarmMessage;//show alarm message
            }

            //show rectify button
            if (!_patient.AlarmRectified)
            {
                _view.BtnRectify.Show();

            }
            _view.RestartTimer();//continue UI timer
        }

        /// <summary>
        /// Handle alarm rectification
        /// </summary>
        private void RectifyAlarm()
        {
            _view.BtnRectify.Hide();//hide the button
            //turn off all alarms
            patientModuleList.ElementAt(0).AlarmRectified = true;
            patientModuleList.ElementAt(1).AlarmRectified = true;
            patientModuleList.ElementAt(2).AlarmRectified = true;
            patientModuleList.ElementAt(3).AlarmRectified = true;

            //register alarm data
            _service.RegisterAlarmData(_staff, patientAlarm);

        }

        /// <summary>
        /// Show the view
        /// </summary>
        public void Run()
        {
            _view.Show();
        }
    }
}
