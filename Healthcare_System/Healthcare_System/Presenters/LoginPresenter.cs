using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Models;

namespace Healthcare_System.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginForm _view;
        private readonly LoginService _service;
        public LoginPresenter(ILoginForm view, LoginService service)
        {
            _view = view;
            _service = service;
            _view.Login += () => Login(_view.StaffID, _view.Password);
        }
        private void Login(string staffID, string password)
        {
            var staff = new Staff { StaffID = staffID, Password = password };
            if (!_service.Login(staff))
            {
                _view.ShowError();
            }
            else
            {
                // successful authorization, next form opening (?)
                frmPatientMonitoring objFrmPatientMonitoring = new frmPatientMonitoring();
                //_view.Close();
                objFrmPatientMonitoring.Show();
            }
        }
        public void Run()
        {
            _view.Show();
        }
    }
}
