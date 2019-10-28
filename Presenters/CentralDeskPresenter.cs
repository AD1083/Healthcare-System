using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Models;
using Healthcare_System.WorkflowManagement;
using Healthcare_System.Views;

namespace Healthcare_System.Presenters
{
    public class CentralDeskPresenter : BasePresenter<ICentralDeskView, Staff>
    {
        private Staff _staff;
        private readonly IRegistrationService _service;
        public CentralDeskPresenter(IApplicationController controller, ICentralDeskView view, IRegistrationService service) : base(controller, view)
        {
            _service = service;
            View.CaptureStartTimeOnLoad += CaptureStartTime;
            View.CaptureEndTimeOnLogoutClick += CaptureEndTime;
        }

        public override void Run(Staff argument)
        {
            _staff = argument;            
            View.Show();
        }
        private void CaptureStartTime(object sender, EventArgs e)
        {
            _staff.Registration = new Registration();
            _staff.Registration.StartTime = View.StartTime;
            _staff.Registration.StaffID = _staff.StaffID;
            _service.RegisterStartTime(_staff.Registration.StaffID, _staff.Registration.StartTime);
        }
        private void CaptureEndTime(object sender, EventArgs e)
        {
            _staff.Registration.EndTime = View.EndTime;
            _service.RegisterEndTime(_staff.Registration.EndTime);
            //Controller.Run<LoginPresenter>();
            View.Close();
        }

    }
}
