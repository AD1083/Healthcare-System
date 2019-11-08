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

            _view.ViewPatient1 += () => ViewPatient(_view.Room1);
            _view.ViewPatient2 += () => ViewPatient(_view.Room2);
            _view.ViewPatient3 += () => ViewPatient(_view.Room3);
            _view.ViewPatient4 += () => ViewPatient(_view.Room4);
            _view.ViewPatient5 += () => ViewPatient(_view.Room5);
            _view.ViewPatient6 += () => ViewPatient(_view.Room6);
            _view.ViewPatient7 += () => ViewPatient(_view.Room7);
            _view.ViewPatient8 += () => ViewPatient(_view.Room8);
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
            
            Patient patient = _simulator.Patients.ElementAt(roomNumber - 1);

            var patientModulePresenter = new PatientModuleViewPresenter(patient, new PatientModuleView(), _simulator);
            patientModulePresenter.Run();
        }

        private void _view_StartSimulation(object sender, EventArgs e)
        {
            _view.StaffID = _staff.StaffID;
            _view.StaffName = $"{_staff.FirstName} {_staff.LastName}";
            _view.StaffRole = _staff.Role;
            _view.StartTime = _staff.Registration.StartTime.Substring(11); //show time only
            //Load patients data
            _view.FirstNameRoom1 = _simulator.Patients.ElementAt(0).FirstName;
            _view.FirstNameRoom2 = _simulator.Patients.ElementAt(1).FirstName;
            _view.FirstNameRoom3 = _simulator.Patients.ElementAt(2).FirstName;
            _view.FirstNameRoom4 = _simulator.Patients.ElementAt(3).FirstName;
            _view.FirstNameRoom5 = _simulator.Patients.ElementAt(4).FirstName;
            _view.FirstNameRoom6 = _simulator.Patients.ElementAt(5).FirstName;
            _view.FirstNameRoom7 = _simulator.Patients.ElementAt(6).FirstName;
            _view.FirstNameRoom8 = _simulator.Patients.ElementAt(7).FirstName;

            _view.LastNameRoom1 = _simulator.Patients.ElementAt(0).LastName;
            _view.LastNameRoom2 = _simulator.Patients.ElementAt(1).LastName;
            _view.LastNameRoom3 = _simulator.Patients.ElementAt(2).LastName;
            _view.LastNameRoom4 = _simulator.Patients.ElementAt(3).LastName;
            _view.LastNameRoom5 = _simulator.Patients.ElementAt(4).LastName;
            _view.LastNameRoom6 = _simulator.Patients.ElementAt(5).LastName;
            _view.LastNameRoom7 = _simulator.Patients.ElementAt(6).LastName;
            _view.LastNameRoom8 = _simulator.Patients.ElementAt(7).LastName;

            _view.ConditionRoom1 = _simulator.Patients.ElementAt(0).Condition;
            _view.ConditionRoom2 = _simulator.Patients.ElementAt(1).Condition;
            _view.ConditionRoom3 = _simulator.Patients.ElementAt(2).Condition;
            _view.ConditionRoom4 = _simulator.Patients.ElementAt(3).Condition;
            _view.ConditionRoom5 = _simulator.Patients.ElementAt(4).Condition;
            _view.ConditionRoom6 = _simulator.Patients.ElementAt(5).Condition;
            _view.ConditionRoom7 = _simulator.Patients.ElementAt(6).Condition;
            _view.ConditionRoom8 = _simulator.Patients.ElementAt(7).Condition;

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
