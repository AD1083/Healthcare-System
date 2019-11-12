using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Views;
using Healthcare_System.Models;
using Healthcare_System.Presenters;
using System.Timers;

namespace Healthcare_System
{
    class PatientModuleViewPresenter
    {
        private readonly Patient _patient;
        private readonly IPatientModuleView _view;
        private readonly CentralDesk _centralDesk;
        private List<Module> patientModuleList;
        private Timer displayReadings;

        public PatientModuleViewPresenter(Patient patient, IPatientModuleView view, CentralDesk centralDesk)
        {
            _patient = patient;
            _view = view;
            _centralDesk = centralDesk;
            patientModuleList = _centralDesk.Patients.ElementAt(_patient.PatientID - 1).Modules;

            _view.LoadPatientData += () => LoadPatientData();
            _view.SetPulseRate += () => SetPulseRate(_view.LowerPulseRate, _view.UpperPulseRate);
            _view.SetBreathingRate += () => SetBreathingRate(_view.LowerBreathingRate, _view.UpperBreathingRate);
            _view.SetBloodPressure += () => SetBloodPressure(_view.LowerBloodPressure, _view.UpperBloodPressure);
            _view.SetTemperature += () => SetTemperature(_view.LowerTemperature, _view.UpperTemperature);

            _view.GoBack += GoBack;
        }

        //private void DisplayCurrentReading(object sender, ElapsedEventArgs e)
        //{
        //    _view.CurPulseRate = patientModuleList.ElementAt(0).CurrentReading;
        //    _view.CurBreathingRate = patientModuleList.ElementAt(1).CurrentReading;
        //    _view.CurBloodPressureRate = patientModuleList.ElementAt(2).CurrentReading;
        //    _view.CurTemperature = patientModuleList.ElementAt(3).CurrentReading;
        //}

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

        private void GoBack(object sender, EventArgs e)
        {
            //hide curr view
            _view.Hide();
            
        }
        private void RectifyAlarm()
        {
            //restart timer
        }

        private void LoadPatientData()
        {
            _view.FirstName = _patient.FirstName;
            _view.LastName = _patient.LastName;
            _view.DOB = _patient.DOB.Substring(0, 10);
            _view.Condition = _patient.Condition;
        }

        public void Run()
        {
            _view.Show();
        }
        public void Hide()
        {
            _view.Hide();
        }
    }
}
