using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare_System.Views;
using Healthcare_System.Models;
using Healthcare_System.Presenters;

namespace Healthcare_System
{
    class PatientModuleViewPresenter
    {
        private readonly Patient _patient;
        private readonly IPatientModuleView _view;
        private readonly Module _module;

        public PatientModuleViewPresenter(Patient patient, IPatientModuleView view, Module module)
        {
            _patient = patient;
            _view = view;
            _module = module;

            _view.RectifyAlarm += _view_RectifyAlarm;
        }

        public void _view_TriggerAlarm(object sender, EventArgs e)
        {
            //generate random reading within module range +- 20
            int randomReading =_module.GeneratePatientData.Next(_module.LowerBoundary -20, _module.UpperBoundary +21);


            //compare generated value to the set boundary
            if ( randomReading> _module.UpperBoundary || randomReading < _module.LowerBoundary)
            {
                _module.alarm.AlarmStatus = true;
            }

            else
            {
                _module.alarm.AlarmStatus = false;
            }



        }
        public void _view_RectifyAlarm(object sender, EventArgs e)
        {
            //  true- alarm is oon false- alarm is off
            //Alarm alarm = new Alarm();
            _module.alarm.AlarmStatus = false;
        }
        public void _view_GoBack()
        {
            //var presenter = new CentralDeskPresenter(new CentralDeskView(), new RegistrationService(), new Staff());
            //presenter.Run();
        }

    }
}
