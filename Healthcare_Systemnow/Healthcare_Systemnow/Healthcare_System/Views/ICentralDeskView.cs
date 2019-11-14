using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Views
{
    public interface ICentralDeskView
    {
        event Action ViewPatient1;
        event Action ViewPatient2;
        event Action ViewPatient3;
        event Action ViewPatient4;
        event Action ViewPatient5;
        event Action ViewPatient6;
        event Action ViewPatient7;
        event Action ViewPatient8;
        
        event EventHandler SignOut;
        event EventHandler StartSimulation;
        event EventHandler ChangePanelColour;

        void Show();
        void Hide();

        string StaffID { set; }
        string StaffRole { set; }
        string StaffName { set; }
        string StartTime { set; }


        string FirstNameRoom1 { set; }
        string LastNameRoom1 { set; }
        string ConditionRoom1 { set; }
        string Room1 { get; }

        string FirstNameRoom2 { set; }
        string LastNameRoom2 { set; }
        string ConditionRoom2 { set; }
        string Room2 { get; }

        string FirstNameRoom3 { set; }
        string LastNameRoom3 { set; }
        string ConditionRoom3 { set; }
        string Room3 { get; }

        string FirstNameRoom4 { set; }
        string LastNameRoom4 { set; }
        string ConditionRoom4 { set; }
        string Room4 { get; }

        string FirstNameRoom5 { set; }
        string LastNameRoom5 { set; }
        string ConditionRoom5 { set; }
        string Room5 { get; }

        string FirstNameRoom6 { set; }
        string LastNameRoom6 { set; }
        string ConditionRoom6 { set; }
        string Room6 { get; }

        string FirstNameRoom7 { set; }
        string LastNameRoom7 { set; }
        string ConditionRoom7 { set; }
        string Room7 { get; }

        string FirstNameRoom8 { set; }
        string LastNameRoom8 { set; }
        string ConditionRoom8 { set; }
        string Room8 { get; }

        Panel PanelRoom1 { get; }
        Panel PanelRoom2 { get; }
        Panel PanelRoom3 { get; }
        Panel PanelRoom4 { get; }
        Panel PanelRoom5 { get; }
        Panel PanelRoom6 { get; }
        Panel PanelRoom7 { get; }
        Panel PanelRoom8 { get; }

    }
}
