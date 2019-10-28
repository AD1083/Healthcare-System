using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
    public interface IRegistrationService
    {
        void RegisterStartTime(string staffID, string startTime);
        void RegisterEndTime(string endTime);
    }
}
