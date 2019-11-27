using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Healthcare_System.Views;
using Healthcare_System.Models;

namespace Healthcare_System.Presenters
{
    public class CentralDeskPresenter
    {
        private readonly ICentralDeskView _view;//instance of the view interface to expose the actual view functionality
        private readonly RegistrationService _service;//backend model for registration opertations
        private readonly Staff _staff;//instance of the signed in staff
        private readonly CentralDesk _centralDesk;//backend  instance of cental desk logic

        /// <summary>
        /// Central Desk presenter constructor, which is an interface between the frontend views and backend models
        /// </summary>
        /// <param name="view"></param>
        /// <param name="service"></param>
        /// <param name="staff"></param>
        /// <param name="patientSimulator"></param>
        public CentralDeskPresenter(ICentralDeskView view, RegistrationService service, Staff staff, CentralDesk patientSimulator)
        {
            //object instances declared in the constructor method call, passed into the presenter fields declared above
            //allows the presenter to interface between the backend model and the front end UI view
            _view = view;
            _service = service;
            _staff = staff;
            _centralDesk = patientSimulator;

            //per patient button click handler
            _view.ViewPatient1 += () => ViewPatient(_view.Room1);
            _view.ViewPatient2 += () => ViewPatient(_view.Room2);
            _view.ViewPatient3 += () => ViewPatient(_view.Room3);
            _view.ViewPatient4 += () => ViewPatient(_view.Room4);
            _view.ViewPatient5 += () => ViewPatient(_view.Room5);
            _view.ViewPatient6 += () => ViewPatient(_view.Room6);
            _view.ViewPatient7 += () => ViewPatient(_view.Room7);
            _view.ViewPatient8 += () => ViewPatient(_view.Room8);

            //button handler for when sign out clicked
            _view.SignOut += SignOut;

            //event handler for loading data to the ui
            _view.LoadData += LoadData;

            //event handler for change panel colour timer
            _view.ChangePanelColour += ChangePanelColour;

        }
        /// <summary>
        /// run a presenter of a patient depending on which room nuber patient is in
        /// </summary>
        /// <param name="roomNum">room position of the patient in the ui</param>
        private void ViewPatient(string roomNum)
        {     
            Int32.TryParse(roomNum.Substring(5, 1), out int roomNumber); //getting room number

            //getting patient from central desk list based on the room number postion
            Patient patient = _centralDesk.Patients.ElementAt(roomNumber - 1);

            //create and run a presenter for the view of the patient
            PatientModuleViewPresenter patientModulePresenter = new PatientModuleViewPresenter(patient, new PatientModuleView(), _centralDesk, _staff, new AlarmRegistrationService());
            patientModulePresenter.Run();
        }

        /// <summary>
        /// registers signing out of the staff into db, hide current view, and run login presenter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignOut(object sender, EventArgs e)
        {
            //capture sign out of the staff
            _service.RecordEndTime(_staff);

            //stop the simulation running
            _centralDesk.DisableTimer();

            this.Hide();//hide current view

            //create and run login view presenter
            LoginPresenter presenter = new LoginPresenter(new LoginView(), new LoginService(), new RegistrationService());
            presenter.Run();

        }

        /// <summary>
        /// load data on the ui
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadData(object sender, EventArgs e)
        {
            //Load staff data
            _view.StaffID = _staff.StaffID;
            _view.StaffName = $"{_staff.FirstName} {_staff.LastName}";
            _view.StaffRole = _staff.Role;
            _view.StartTime = _staff.Registration.StartTime.Substring(11); //show time only

            //Load patients data
            //Output each patient's first name to the UI
            _view.FirstNameRoom1 = _centralDesk.Patients.ElementAt(0).FirstName;
            _view.FirstNameRoom2 = _centralDesk.Patients.ElementAt(1).FirstName;
            _view.FirstNameRoom3 = _centralDesk.Patients.ElementAt(2).FirstName;
            _view.FirstNameRoom4 = _centralDesk.Patients.ElementAt(3).FirstName;
            _view.FirstNameRoom5 = _centralDesk.Patients.ElementAt(4).FirstName;
            _view.FirstNameRoom6 = _centralDesk.Patients.ElementAt(5).FirstName;
            _view.FirstNameRoom7 = _centralDesk.Patients.ElementAt(6).FirstName;
            _view.FirstNameRoom8 = _centralDesk.Patients.ElementAt(7).FirstName;

            //Output each patient's last name to the UI
            _view.LastNameRoom1 = _centralDesk.Patients.ElementAt(0).LastName;
            _view.LastNameRoom2 = _centralDesk.Patients.ElementAt(1).LastName;
            _view.LastNameRoom3 = _centralDesk.Patients.ElementAt(2).LastName;
            _view.LastNameRoom4 = _centralDesk.Patients.ElementAt(3).LastName;
            _view.LastNameRoom5 = _centralDesk.Patients.ElementAt(4).LastName;
            _view.LastNameRoom6 = _centralDesk.Patients.ElementAt(5).LastName;
            _view.LastNameRoom7 = _centralDesk.Patients.ElementAt(6).LastName;
            _view.LastNameRoom8 = _centralDesk.Patients.ElementAt(7).LastName;

            //Output each patient's admitted condition to the UI
            _view.ConditionRoom1 = _centralDesk.Patients.ElementAt(0).Condition;
            _view.ConditionRoom2 = _centralDesk.Patients.ElementAt(1).Condition;
            _view.ConditionRoom3 = _centralDesk.Patients.ElementAt(2).Condition;
            _view.ConditionRoom4 = _centralDesk.Patients.ElementAt(3).Condition;
            _view.ConditionRoom5 = _centralDesk.Patients.ElementAt(4).Condition;
            _view.ConditionRoom6 = _centralDesk.Patients.ElementAt(5).Condition;
            _view.ConditionRoom7 = _centralDesk.Patients.ElementAt(6).Condition;
            _view.ConditionRoom8 = _centralDesk.Patients.ElementAt(7).Condition;

        }

        /// <summary>
        /// determines the colour of each patient's panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePanelColour(object sender, EventArgs e)
        {
            List<Color> panelsColours = new List<Color>(); //create blank list of colours
            panelsColours = _centralDesk.ChangePanelColour(); //calls on the centrak desk to determine the colours for the list

            //if the list is not null or contains no elemnts then set the colours for each panel
            if (panelsColours != null || panelsColours.Count == 0) 
            {
                int panelNum = 1; //local count to identify panel patient
                foreach (Color color in panelsColours)
                {
                    PanelColourChange(panelNum, color); //pass to the panel coolour change method which sets the colour on the UI view

                    panelNum++;
                }
            }
        }

        /// <summary>
        /// changes the given panel to the colour provided
        /// </summary>
        /// <param name="panelNum"> the panel who's colour should be changed</param>
        /// <param name="color"> the colour to change the panel to - red or white</param>
        private void PanelColourChange(int panelNum, Color color)
        {
            switch (panelNum) //switch over the room numbers 1 to 8, to assign the colour
            {
                case 1:
                    _view.PanelRoom1.BackColor = color;
                    break;
                case 2:
                    _view.PanelRoom2.BackColor = color;
                    break;
                case 3:
                    _view.PanelRoom3.BackColor = color;
                    break;
                case 4:
                    _view.PanelRoom4.BackColor = color;
                    break;
                case 5:
                    _view.PanelRoom5.BackColor = color;
                    break;
                case 6:
                    _view.PanelRoom6.BackColor = color;
                    break;
                case 7:
                    _view.PanelRoom7.BackColor = color;
                    break;
                case 8:
                    _view.PanelRoom8.BackColor = color;
                    break;
            }
        }

        /// <summary>
        /// Show the view
        /// </summary>
        public void Run()
        {
            _view.Show();
        }

        /// <summary>
        /// Hide the view
        /// </summary>
        public void Hide()
        {
            _view.Hide();
        }
    }
}
