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
            _view.Login += () => Login(_view.StaffID, _view.Password);
        }

      
        private void Login(string staffID, string password)
        {
            var staff = new Staff { StaffID = staffID, Password = password };
            if (!_service.Login(staff))
            {
                _view.ShowError("Check your Staff ID and password");
            }
            else
            {
                // successful authorization, next form opening (?)
                _regService.RecordStartTime(staff);
                var presenter = new CentralDeskPresenter(new CentralDeskView(), new RegistrationService(), staff);
                presenter.Run();
                
            }
        }
        public void Run()
        {
            _view.Show();
        }
    }
}
