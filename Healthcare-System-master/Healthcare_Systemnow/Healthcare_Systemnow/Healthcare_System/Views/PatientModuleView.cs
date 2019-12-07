using System;
using System.Windows.Forms;

namespace Healthcare_System.Views
{
    //Windows forms inherting class that defines the events that occur and properties shown on the Patient Module UI
    public partial class PatientModuleView : Form, IPatientModuleView
    {

        /// <summary>
        /// Constructor for the view which initialises the form and defines the event handlers for the events raised by the UI
        /// </summary>
        public PatientModuleView()
        {
            InitializeComponent();
            this.Load += (sender, args) => Invoke(LoadPatientData); //event handlder for the event of loading the UI

            //defining the event handler to use when the set button of each module is clicked
            btnSetPulseRate.Click += (sender, args) => Invoke(SetPulseRate);
            btnSetBreathingRate.Click += (sender, args) => Invoke(SetBreathingRate);
            btnSetBloodPressure.Click += (sender, args) => Invoke(SetBloodPressure);
            btnSetTemperature.Click += (sender, args) => Invoke(SetTemperature);

            btnRectify.Hide(); //hide rectify button until needed to rectify patient alarm
            btnRectify.Click += (sender, args) => Invoke(RectifyAlarm); //handler for event raised by the recify button when clicked

            btnBack.Click += BtnBack_Click; //defines event handler for bak button click event
        }

        //properties from the interface that are defined with the UI element they represent
        //allows access by the presenter to the UI element so that the presenter can pass the data from the backend into the UI to be displayed
        public Button BtnRectify { get { return btnRectify; } }
        public PictureBox PictureBox { get { return pictureBox; } set { pictureBox = value; } }
        public string FirstName { get { return lblFirstName.Text; } set { lblFirstName.Text = value; } }
        public string LastName { get { return lblLastName.Text; } set { lblLastName.Text = value; } }
        public string DOB { get { return lblDOB.Text; } set { lblDOB.Text = value; } }
        public string Condition { get { return lblCondition.Text; } set { lblCondition.Text = value; } }
        public string LowerPulseRate { get { return txtboxLowBoundaryPulseRate.Text; } set { txtboxLowBoundaryPulseRate.Text = value; } }
        public string UpperPulseRate { get { return txtxboxUpperBoundaryPulseRate.Text; } set { txtxboxUpperBoundaryPulseRate.Text = value; } }
        public string LowerBreathingRate { get { return txtBoxLowBoundaryBreathingRate.Text; } set { txtBoxLowBoundaryBreathingRate.Text = value; } }
        public string UpperBreathingRate { get { return txtboxUpperBoundaryBreathingRate.Text; } set { txtboxUpperBoundaryBreathingRate.Text = value; } }
        public string LowerBloodPressure { get { return txtboxLowBoundaryBloodPressure.Text; } set { txtboxLowBoundaryBloodPressure.Text = value; } }
        public string UpperBloodPressure { get { return txtboxUpperboundaryBloodPressure.Text; } set { txtboxUpperboundaryBloodPressure.Text = value; } }
        public string LowerTemperature { get { return txtboxLowBoundaryTemperature.Text; } set { txtboxLowBoundaryTemperature.Text = value; } }
        public string UpperTemperature { get { return txtboxUpperBoundaryTemperture.Text; } set { txtboxUpperBoundaryTemperture.Text = value; } }
        public string CurPulseRate { get { return lblCurPulseRate.Text; } set { lblCurPulseRate.Text = value; } }
        public string CurBreathingRate { get { return lblCurBreathingRate.Text; } set { lblCurBreathingRate.Text = value; } }
        public string CurBloodPressureRate { get { return lblCurBloodPressure.Text; } set { lblCurBloodPressure.Text = value; } }
        public string CurTemperature { get { return lblCurTemperature.Text; } set { lblCurTemperature.Text = value; } }
        public string AlarmMessage { get { return lblAlarmMessage.Text; } set { lblAlarmMessage.Text = value; } }

        //interface event defintions for events that can be raised by the UI
        public event Action SetPulseRate;
        public event Action SetBreathingRate;
        public event Action SetBloodPressure;
        public event Action SetTemperature;
        public event Action RectifyAlarm;
        public event Action LoadPatientData;
        public event EventHandler GoBack;
        public event EventHandler UpdatePatientModuleData;

        /// <summary>
        /// event handler method for the back button click event
        /// </summary>
        /// <param name="sender">object that raised the event</param>
        /// <param name="e">arguments of the event</param>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (GoBack != null) GoBack(this, EventArgs.Empty);
        }

        /// <summary>
        /// Method to invoke the event of an action triggered from user intercation with the UI
        /// </summary>
        /// <param name="action">the Action was raised by the UI</param>
        private void Invoke(Action action)
        {
            //if the action is not null, then invooke the action to the presenter
            if (action != null) action();
        }

        /// <summary>
        /// method to handle vents raised by the Ui timer which will update the display of module data on the UI
        /// </summary>
        /// <param name="sender">object that raised the event</param>
        /// <param name="e">arguments of the event</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (UpdatePatientModuleData != null) UpdatePatientModuleData(this, EventArgs.Empty);
        }

        /// <summary>
        /// method definition for interface Show method, shows the form to the user
        /// </summary>
        public new void Show()
        {
            this.ShowDialog();
        }

        /// <summary>
        /// public method to allow the UI timer to be stopped whilst the UI is updated with the new data outputs from the backend through the presenter
        /// </summary>
        public void StopTimer()
        {
            timer.Stop();
        }

        /// <summary>
        /// public method to allow the timer to be restarted once the view has been updated with the new data
        /// </summary>
        public void RestartTimer()
        {
            timer.Start();
        }

    }
}
