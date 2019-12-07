using System;

namespace Healthcare_System.Views
{
    public interface ILoginView
    {
        //properties for staff details credentials
        string StaffID { get; }
        string Password { get; }
        string Role { get; }
        //view event
        event Action Login;
        void ShowError(string message);//show pop-up message
        void Show();//show current view
        void Hide();//hide current view

    }
}
