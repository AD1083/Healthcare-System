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
        private readonly CentralDesk _simulator;
        public CentralDeskPresenter(ICentralDeskView view, RegistrationService service, Staff staff, CentralDesk patientSimulator)
        {
            _view = view;
            _service = service;
            _staff = staff;
            _simulator = patientSimulator;

            _view.ViewPatient += () => ViewPatient(_view.Room1);
            _view.ViewPatient += () => ViewPatient(_view.Room2);
            _view.ViewPatient += () => ViewPatient(_view.Room3);
            _view.ViewPatient += () => ViewPatient(_view.Room4);
            _view.ViewPatient += () => ViewPatient(_view.Room5);
            _view.ViewPatient += () => ViewPatient(_view.Room6);
            _view.ViewPatient += () => ViewPatient(_view.Room7);
            _view.ViewPatient += () => ViewPatient(_view.Room8);
            _view.SignOut += SignOut;

            _view.StartSimulation += _view_StartSimulation;

        }

        private void SignOut(object sender, EventArgs e)
        {
            _service.RecordEndTime(_staff);
            
            var presenter = new LoginPresenter(new LoginView(), new LoginService(), new RegistrationService());
            _view.Hide();
            presenter.Run();
           
        }


        private void ViewPatient(string roomNum)
        {
            Int32.TryParse(roomNum.Substring(5, 1), out int roomNumber);
            //Patient patient = _simulator.Patients.ElementAt(roomNumber);

            var patientModulePresenter = new PatientModuleViewPresenter(new Patient(), new PatientModuleView());
            patientModulePresenter.Run();
        }

        private void _view_StartSimulation(object sender, EventArgs e)
        {
            _view.StaffID = _staff.StaffID;
            _view.StaffName = $"{_staff.FirstName} {_staff.LastName}";
            _view.StaffRole = _staff.Role;
            //start time label
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
