using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// STAThread attribute specifies the Forms application runs on a single thread
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginPage());
        }
    }
}
