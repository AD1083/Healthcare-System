using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Healthcare_System.Models
{
    public class RegistrationService : IRegistrationService
    {
        List<string> regList = new List<string>();
        //StringBuilder strbld = new StringBuilder();

        string filepath = @"C:\Registrations";
        /// <summary>
        /// Puts into database Registration table staf registration info
        /// </summary>
        /// <param name="registration"></param>
        public void RegisterStartTime(string staffID, string startTime)
        {
            regList.Add(startTime);
            //strbld.AppendFormat("{0}, {1}", staffID, startTime);
            //File.AppendAllText(filepath, strbld.ToString());
        }

        public void RegisterEndTime(string endTime)
        {
            regList.Add(endTime);
            //strbld.AppendFormat("{0}", endTime);
            //File.AppendAllText(filepath, strbld.ToString());
        }
    }
}
