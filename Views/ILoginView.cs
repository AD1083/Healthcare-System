﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Views
{
    public interface ILoginView :IView
    {
        string StaffID { get; }
        string Password { get; }
        event Action Login;
        void ShowError();
        void Show();
        
    }
}
