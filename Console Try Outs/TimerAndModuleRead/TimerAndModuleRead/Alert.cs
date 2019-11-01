using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerAndModuleRead
{
    class Alert
    {
        public string AlertMessage { get; }
        public bool SendAlert { get; }

        public Alert(bool sendAlert)
        {
            SendAlert = sendAlert;
        }

        public Alert(string alertMessage, bool sendAlert)
        {
            AlertMessage = alertMessage;
            SendAlert = sendAlert;
        }
    }
}
