using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Models;
using Healthcare_System.Views;

namespace Healthcare_System.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly LoginService _service;
        private readonly RegistrationService _regService;
        public LoginPresenter(ILoginView view, LoginService service, RegistrationService regService)
        {
            _view = view;
            _service = service;
            _regService = regService;
            _view.Login += () => Login(_view.StaffID, _view.Password, _view.Role);
        }


        private void Login(string staffID, string password, string role)
        {
            Staff staff = new Staff { StaffID = staffID, Password = password, Role = role };
            if (!_service.Login(ref staff)) //by reference as not all the staff properties have been filled, so need to be updated from the database
            {
                _view.ShowError("Check your Staff ID and password"); //display an error message for failed login using an incorrect staff id/password
            }
            else
            {
                // successful authorization, next form opening (?)
                _regService.RecordStartTime(staff);
                if (staff.Role == "Nurse" || staff.Role == "Consultant")
                {
                    CentralDeskPresenter presenter = new CentralDeskPresenter(new CentralDeskView(), new RegistrationService(), staff, new CentralDesk(staff));
                    _view.Hide();

                    presenter.Run();
                }
                else
                {
                    ManagerViewPresenter presenter = new ManagerViewPresenter(new ManagerialView(), new RegistrationService(), new ManagerialService(), staff);
                    _view.Hide();
                    presenter.Run();
                }
            }
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
