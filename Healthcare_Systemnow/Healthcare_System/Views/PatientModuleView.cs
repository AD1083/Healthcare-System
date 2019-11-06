using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthcare_System.Views
{
    public partial class PatientModuleView : Form, IPatientModuleView
    {
        
        public PatientModuleView()
        {
            InitializeComponent();
            this.Load += (sender, args) => Invoke(LoadPatientData);

            btnSetPulseRate.Click += (sender, args) => Invoke(SetPulseRate);
            btnSetBreathingRate.Click += (sender, args) => Invoke(SetBreathingRate);
            btnSetBloodPressure.Click += (sender, args) => Invoke(SetBloodPressure);
            btnSetTemperature.Click += (sender, args) => Invoke(SetTemperature);

            btnRectify.Hide();
            btnRectify.Click += (sender, args) => Invoke(RectifyAlarm);

            btnBack.Click += BtnBack_Click;

        }
        // properties
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

        //Actions
        public event Action SetPulseRate;
        public event Action SetBreathingRate;
        public event Action SetBloodPressure;
        public event Action SetTemperature;
        public event Action RectifyAlarm;
        public event Action LoadPatientData;
        public event EventHandler GoBack;
        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (GoBack != null) GoBack(this, EventArgs.Empty);
        }

        private void Invoke(Action action)
        {
            if (action != null) action();
        }

        public new void Show()
        {
            this.ShowDialog();
        }
       

    }
}
