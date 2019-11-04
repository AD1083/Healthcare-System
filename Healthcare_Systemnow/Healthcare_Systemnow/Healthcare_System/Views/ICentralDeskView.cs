using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Views
{
    public interface ICentralDeskView
    {
        event Action ViewPatient;
        event EventHandler SignOut;
        event EventHandler StartSimulation;

        string FirstNameRoom1 { get; set; }
        string LastnameRoom1 { get; set; }
        string ConditionRoom1 { get; set; }
        string Room1 { get; set; }
        void Show();
    }
}
