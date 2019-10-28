﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Models;
using Healthcare_System.WorkflowManagement;
using Healthcare_System.Views;

namespace Healthcare_System.Presenters
{
    public class LoginPresenter : BasePresenter<ILoginView>
    {
        private readonly ILoginService _service;
        public LoginPresenter(IApplicationController controller, ILoginView view, ILoginService service) : base(controller, view)
        {

            _service = service;
            View.Login += () => Login(View.StaffID, View.Password);
        }
        private void Login(string staffID, string password)
        {
            var staff = new Staff { StaffID = staffID, Password = password };
            if (!_service.Login(staff))
            {
                View.ShowError();
            }
            else
            {
                Controller.Run<CentralDeskPresenter, Staff>(staff);
                View.Close();
            }
        }
        //public void Run()
        //{
        //    _view.Show();
        //}
    }
}
