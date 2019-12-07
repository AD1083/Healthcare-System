using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Views;
using Healthcare_System.Models;

namespace Healthcare_System.Presenters
{
    /// <summary>
    /// presenter class acts as the middle-man or interface between the backend classes and the front end UI to provide abstarction between these two
    /// </summary>
    public class ManagerViewPresenter
    {
        //attributes of the Manager presenter to contain the instances of the backend classes and the interface used for the view
        private readonly RegistrationService _serviceRegistration;
        private readonly ManagerialService _serviceManagerial;
        private readonly IManagerView _view;
        private readonly Staff _staff;

        /// <summary>
        /// constructor of the mangerial presenter
        /// </summary>
        /// <param name="view">the interface instance used for the UI</param>
        /// <param name="serviceRegistration">the instance of the registration service backend class</param>
        /// <param name="serviceManagerial">instance of the mangerial service backend class</param>
        /// <param name="staff">staff obect created by a login to the managerial UI</param>
        public ManagerViewPresenter(IManagerView view, RegistrationService serviceRegistration, ManagerialService serviceManagerial, Staff staff)
        {
            //assign the instances of each class from the parameter to the attributes of the presenter
            //allows the presenter to then interface between the backend and the frontend
            _view = view;
            _serviceRegistration = serviceRegistration;
            _serviceManagerial = serviceManagerial;
            _staff = staff;

            //declare the methods that handle events raised by the interface instance
            _view.SignOut += SignOut;
            _view.LoadData += LoadData;
        }

        /// <summary>
        /// Method to handle the event raised in the interface for the loading of the Manager UI
        /// Fills the staff property UI elements with the data from the backend staff object using the interface instance
        /// Assign the database data that is acessed from the backedn service method returns to the data grid on the UI
        /// </summary>
        /// <param name="sender">object that raised the event</param>
        /// <param name="e">arguments of the event</param>
        private void LoadData(object sender, EventArgs e)
        {
            //display the staff properties
            _view.StaffID = _staff.StaffID;
            _view.StaffName = $"{_staff.FirstName} {_staff.LastName}";
            _view.StaffRole = _staff.Role;
            _view.StartTime = _staff.Registration.StartTime.Substring(11); //show time only substring to take out the date portion

            //diaply the data from the database backend
            _view.DataGridRegistrations.DataSource = _serviceManagerial.GetRegistrations(); //calls the service backend to get registration database data
            _view.DataGridAlarms.DataSource = _serviceManagerial.GetAlarms(); //calls service backedn to get alarm database data
        }

        /// <summary>
        /// Method to handle the event raised by the interface instance when manager clicks sign out
        /// Records the sign out time, hides the manager view and then creates a new login presenter for the view to switch to
        /// </summary>
        /// <param name="sender">object that raised the event</param>
        /// <param name="e">arguments of the event</param>
        private void SignOut(object sender, EventArgs e)
        {
            _serviceRegistration.RecordEndTime(_staff);
            LoginPresenter presenter = new LoginPresenter(new LoginView(), new LoginService(), new RegistrationService());
            _view.Hide();
            presenter.Run();

        }

        /// <summary>
        /// Method to show the Manager UI when the manager presenter created in the the Login Presenter
        /// Accesses the show method of the view
        /// </summary>
        public void Run()
        {
            _view.Show();
        }
    }
}
