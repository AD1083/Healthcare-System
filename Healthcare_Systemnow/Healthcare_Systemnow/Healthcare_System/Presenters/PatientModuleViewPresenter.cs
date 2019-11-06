using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Views;
using Healthcare_System.Models;
using Healthcare_System.Presenters;

namespace Healthcare_System
{
    class PatientModuleViewPresenter
    {
        private readonly Patient _patient;
        private readonly IPatientModuleView _view;
        

        public PatientModuleViewPresenter(Patient patient, IPatientModuleView view)
        {
            _patient = patient;
            _view = view;

            _view.LoadPatientData += () => LoadPatientData(); 
            _view.SetPulseRate += () => SetPulseRate(_view.LowerPulseRate, _view.UpperPulseRate);
            _view.SetBreathingRate += () => SetBreathingRate(_view.LowerBreathingRate, _view.UpperBreathingRate);
            _view.SetBloodPressure += () => SetBloodPressure(_view.LowerBloodPressure, _view.UpperBloodPressure);
            _view.SetTemperature += () => SetTemperature(_view.LowerTemperature, _view.UpperTemperature);

            _view.GoBack += () => GoBack();
        }

        private void SetPulseRate(string lowerPulseRate, string upperPulseRate)
        {
            
        }
        private void SetBreathingRate(string lowerBreathingRate, string upperBreathingRate)
        {

        }
        private void SetBloodPressure(string lowerBloodPressure, string upperBloodPressure)
        {

        }
        private void SetTemperature(string lowerTemperature, string upperTemperature)
        {

        }

        private void GoBack()
        {
            //run previous presenter view, hide curr view
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
            _view.DOB = _patient.DOB;
            _view.Condition = _patient.Condition;
        }

        public void Run()
        {
            _view.ShowDialog();
        }
    }
}
