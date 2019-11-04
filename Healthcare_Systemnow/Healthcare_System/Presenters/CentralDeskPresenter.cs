using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Views;
using Healthcare_System.Models;

namespace Healthcare_System.Presenters
{
    public class CentralDeskPresenter
    {
        private readonly RegistrationService _service;
        private readonly ICentralDeskView _view;
        private readonly Staff _staff;

        //central desk backend class in model - gets 

        // private readonly PatientSimulator _simulator;
        public CentralDeskPresenter(ICentralDeskView view, RegistrationService service, Staff staff)
        {
            _view = view;
            _service = service;
            _staff = staff;

            _view.ViewPatient += () => ViewPatient(_view.Room1); ;
            _view.SignOut += _view_SignOut;

            //_view.StartPatientSimulation += _view_StartPatientSimulation;
        }

        private void _view_SignOut(object sender, EventArgs e)
        {
            _service.RecordEndTime(_staff);
        }

        private void ViewPatient(string roomNum)
        {
            Int32.TryParse(roomNum.Substring(5, 1), out int roomNumber);

            //var patientModulePresenter = new PatientModulePresenter();
            //patientModulePresenter.Run();
        }

        //private void _view_StartPatientSimulation(object sender, EventArgs e)
        //{
        //    Patient patient1 = new Patient();
        //    _simulator.SimulatePatient(patient1);//repeat for the rest of the patients
        //}



        public void Run()
        {
            _view.Show();
        }
    }
}
