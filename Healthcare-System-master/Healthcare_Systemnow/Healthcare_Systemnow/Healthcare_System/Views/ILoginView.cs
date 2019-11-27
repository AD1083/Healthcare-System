using System;

namespace Healthcare_System.Views
{
    public interface ILoginView
    {
        string StaffID { get; }
        string Password { get; }
        string Role { get; }
        event Action Login;
        void ShowError(string message);
        void Show();
        void Hide();

    }
}
