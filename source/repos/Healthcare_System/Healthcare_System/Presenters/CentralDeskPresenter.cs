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
        public CentralDeskPresenter(IApplicationController controller, ICentralDeskView view) : base(controller, view)
        {

        }

        public override void Run(Staff argument)
        {
            _staff = argument;
            
            View.Show();
        }
    }
}
