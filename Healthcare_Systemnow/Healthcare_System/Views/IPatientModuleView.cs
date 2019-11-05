using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System
{
    public interface IPatientModuleView
    {
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

        event Action LoadPatientData;
        event Action RectifyAlarm;
        event Action SetPulseRate;
        event Action SetBreathingRate;
        event Action SetBloodPressure;
        event Action SetTemperature;
        event Action GoBack;

        void Show();
        void Hide();

    }
}

