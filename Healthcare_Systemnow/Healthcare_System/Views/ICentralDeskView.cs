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
        void Show();
        void Hide();

        string StaffID {  set; }
        string StaffRole {  set; }
        string StaffName {  set; }


        string FirstNameRoom1 {  set; }
        string LastNameRoom1 {  set; }
        string ConditionRoom1 { set; }
        string Room1 { get; }

        string FirstNameRoom2 { set; }
        string LastNameRoom2 { set; }
        string ConditionRoom2 { set; }
        string Room2 { get; }

        string FirstNameRoom3 {  set; }
        string LastNameRoom3 { set; }
        string ConditionRoom3{  set; }
        string Room3 { get; }

        string FirstNameRoom4 {  set; }
        string LastNameRoom4 { set; }
        string ConditionRoom4 { set; }
        string Room4 { get; }

        string FirstNameRoom5 {set; }
        string LastNameRoom5 {  set; }
        string ConditionRoom5 { set; }
        string Room5 { get;  }

        string FirstNameRoom6 {  set; }
        string LastNameRoom6 {set; }
        string ConditionRoom6 { set; }
        string Room6 { get;  }

        string FirstNameRoom7 { set; }
        string LastNameRoom7 { set; }
        string ConditionRoom7 {  set; }
        string Room7 { get;  }

        string FirstNameRoom8 {  set; }
        string LastNameRoom8 {set; }
        string ConditionRoom8 { set; }
        string Room8 { get; }
        
    }
}
