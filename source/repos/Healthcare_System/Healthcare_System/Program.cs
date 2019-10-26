using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Healthcare_System.Models;
using Healthcare_System.Presenters;
using Healthcare_System.Views;
using Healthcare_System.WorkflowManagement;


namespace Healthcare_System
{
    internal static class Program
    {

        public static readonly ApplicationContext Context = new ApplicationContext();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var adapter = new LightInjectAdapter();
            var controller = new ApplicationController(adapter)
                .RegisterView<ILoginView, frmLogin>()
                .RegisterView<ICentralDeskView, CentralDeskView>()
                .RegisterService<ILoginService, LoginService>()
                .RegisterInstance(new ApplicationContext());

            controller.Run<LoginPresenter>();

        }
    }
}
