using System;
using System.Windows.Forms;

namespace Healthcare_System
{
    /// <summary>
    /// interface of the patinet modue view outlines the properties, methods, events and actions that need to be defined
    /// in the inheriting presenter and view classes
    /// </summary>
    public interface IPatientModuleView
    {
        //windows forms UI elemnts that have properties to be defined
        Button BtnRectify { get; }
        PictureBox PictureBox { get; set; }

        //events that can be raised by the inheriting classes
        event Action LoadPatientData;
        event Action RectifyAlarm;
        event Action SetPulseRate;
        event Action SetBreathingRate;
        event Action SetBloodPressure;
        event Action SetTemperature;
        event EventHandler GoBack;
        event EventHandler UpdatePatientModuleData;

        //methods utilised by the presenter to control the view
        void Show();
        void Hide();
        void StopTimer();
        void RestartTimer();

        //properties of the interface used by the presenter to pass data into the UI elements, which has come from the backend
        string FirstName { get; set; }
        string LastName { get; set; }
        string DOB { get; set; }
        string Condition { get; set; }
        string LowerPulseRate { get; set; }
        string UpperPulseRate { get; set; }
        string LowerBreathingRate { get; set; }
        string UpperBreathingRate { get; set; }
        string LowerBloodPressure { get; set; }
        string UpperBloodPressure { get; set; }
        string LowerTemperature { get; set; }
        string UpperTemperature { get; set; }
        string CurPulseRate { get; set; }
        string CurBreathingRate { get; set; }
        string CurBloodPressureRate { get; set; }
        string CurTemperature { get; set; }
        string AlarmMessage { get; set; }
    }
}

