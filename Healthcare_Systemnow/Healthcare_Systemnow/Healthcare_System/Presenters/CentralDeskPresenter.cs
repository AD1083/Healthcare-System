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
        private readonly CentralDesk _centralDesk;
        public CentralDeskPresenter(ICentralDeskView view, RegistrationService service, Staff staff, CentralDesk patientSimulator)
        {
            _view = view;
            _service = service;
            _staff = staff;
            _centralDesk = patientSimulator;

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
            _view.ChangePanelColour += _view_ChangePanelColour;

        }

        private void _view_ChangePanelColour(object sender, EventArgs e)
        {
            List<int> panelsToChange = new List<int>();
            panelsToChange = _centralDesk.ChangePanelColour();
            foreach (int i in panelsToChange)
            {
                PanelColourChange(i);
            }
        }

        private void PanelColourChange(int panelNum)
        {
            switch(panelNum)
            {
                case 1:
                    _view.PanelRoom1.BackColor = System.Drawing.Color.Red;
                    break;
                case 22:
                    _view.PanelRoom2.BackColor = System.Drawing.Color.Red;
                    break;
                case 3:
                    _view.PanelRoom3.BackColor = System.Drawing.Color.Red;
                    break;
                case 4:
                    _view.PanelRoom4.BackColor = System.Drawing.Color.Red;
                    break;
                case 5:
                    _view.PanelRoom5.BackColor = System.Drawing.Color.Red;
                    break;
                case 6:
                    _view.PanelRoom6.BackColor = System.Drawing.Color.Red;
                    break;
                case 7:
                    _view.PanelRoom7.BackColor = System.Drawing.Color.Red;
                    break;
                case 8:
                    _view.PanelRoom8.BackColor = System.Drawing.Color.Red;
                    break;
            }
        }

        private void SignOut(object sender, EventArgs e)
        {
            _service.RecordEndTime(_staff);
            _centralDesk.DisableTimer();
            var presenter = new LoginPresenter(new LoginView(), new LoginService(), new RegistrationService());

            _view.Hide();

            presenter.Run();

        }

        private void ViewPatient(string roomNum)
        {
            Int32.TryParse(roomNum.Substring(5, 1), out int roomNumber);

            Patient patient = _centralDesk.Patients.ElementAt(roomNumber - 1);

            var patientModulePresenter = new PatientModuleViewPresenter(patient, new PatientModuleView(), _centralDesk, _staff, new AlarmRegistrationService());
            patientModulePresenter.Run();
        }

        private void _view_StartSimulation(object sender, EventArgs e)
        {
            _view.StaffID = _staff.StaffID;
            _view.StaffName = $"{_staff.FirstName} {_staff.LastName}";
            _view.StaffRole = _staff.Role;
            _view.StartTime = _staff.Registration.StartTime.Substring(11); //show time only
            //Load patients data
            _view.FirstNameRoom1 = _centralDesk.Patients.ElementAt(0).FirstName;
            _view.FirstNameRoom2 = _centralDesk.Patients.ElementAt(1).FirstName;
            _view.FirstNameRoom3 = _centralDesk.Patients.ElementAt(2).FirstName;
            _view.FirstNameRoom4 = _centralDesk.Patients.ElementAt(3).FirstName;
            _view.FirstNameRoom5 = _centralDesk.Patients.ElementAt(4).FirstName;
            _view.FirstNameRoom6 = _centralDesk.Patients.ElementAt(5).FirstName;
            _view.FirstNameRoom7 = _centralDesk.Patients.ElementAt(6).FirstName;
            _view.FirstNameRoom8 = _centralDesk.Patients.ElementAt(7).FirstName;

            _view.LastNameRoom1 = _centralDesk.Patients.ElementAt(0).LastName;
            _view.LastNameRoom2 = _centralDesk.Patients.ElementAt(1).LastName;
            _view.LastNameRoom3 = _centralDesk.Patients.ElementAt(2).LastName;
            _view.LastNameRoom4 = _centralDesk.Patients.ElementAt(3).LastName;
            _view.LastNameRoom5 = _centralDesk.Patients.ElementAt(4).LastName;
            _view.LastNameRoom6 = _centralDesk.Patients.ElementAt(5).LastName;
            _view.LastNameRoom7 = _centralDesk.Patients.ElementAt(6).LastName;
            _view.LastNameRoom8 = _centralDesk.Patients.ElementAt(7).LastName;

            _view.ConditionRoom1 = _centralDesk.Patients.ElementAt(0).Condition;
            _view.ConditionRoom2 = _centralDesk.Patients.ElementAt(1).Condition;
            _view.ConditionRoom3 = _centralDesk.Patients.ElementAt(2).Condition;
            _view.ConditionRoom4 = _centralDesk.Patients.ElementAt(3).Condition;
            _view.ConditionRoom5 = _centralDesk.Patients.ElementAt(4).Condition;
            _view.ConditionRoom6 = _centralDesk.Patients.ElementAt(5).Condition;
            _view.ConditionRoom7 = _centralDesk.Patients.ElementAt(6).Condition;
            _view.ConditionRoom8 = _centralDesk.Patients.ElementAt(7).Condition;

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
