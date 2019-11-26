using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Views;
using Healthcare_System.Models;

namespace Healthcare_System.Presenters
{
    public class ManagerViewPresenter
    {
        private readonly RegistrationService _serviceRegistration;
        private readonly ManagerialService _serviceManagerial;
        private readonly IManagerView _view;
        private readonly Staff _staff;

        public ManagerViewPresenter(IManagerView view, RegistrationService serviceRegistration, ManagerialService serviceManagerial, Staff staff)
        {
            _view = view;
            _serviceRegistration = serviceRegistration;
            _serviceManagerial = serviceManagerial;
            _staff = staff;

            _view.SignOut += SignOut;
            _view.LoadData += LoadData;
        }

        private void LoadData(object sender, EventArgs e)
        {
            _view.StaffID = _staff.StaffID;
            _view.StaffName = $"{_staff.FirstName} {_staff.LastName}";
            _view.StaffRole = _staff.Role;
            _view.StartTime = _staff.Registration.StartTime.Substring(11); //show time only

            _view.DataGridRegistrations.DataSource = _serviceManagerial.GetRegistrations();
            _view.DataGridAlarms.DataSource = _serviceManagerial.GetAlarms();
        }

        private void SignOut(object sender, EventArgs e)
        {
            _serviceRegistration.RecordEndTime(_staff);
            var presenter = new LoginPresenter(new LoginView(), new LoginService(), new RegistrationService());
            _view.Hide();
            presenter.Run();

        }
        public void Run()
        {
            _view.Show();
        }
    }
}
