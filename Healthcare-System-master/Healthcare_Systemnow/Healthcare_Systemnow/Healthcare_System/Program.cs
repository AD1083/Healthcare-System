using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare_System.Models;
using Healthcare_System.Presenters;


namespace Healthcare_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var presenter = new LoginPresenter(new LoginView(), new LoginService(), new RegistrationService());
            presenter.Run();

        }
    }
}
