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
            presenter.Run();
            
        }
       

       private void ViewPatient(string roomNum)
       {
            Int32.TryParse(roomNum.Substring(6, 1), out int roomNumber);

           // var patientModulePresenter = new PatientModuleViewPresenter(Patient(), new PatientModuleView(), new Module());
            //patientModulePresenter.Run();
       }

        private void _view_StartSimulation(object sender, EventArgs e)
        {
 

        }



        public void Run()
        {
            _view.Show();
        }
    }
}
