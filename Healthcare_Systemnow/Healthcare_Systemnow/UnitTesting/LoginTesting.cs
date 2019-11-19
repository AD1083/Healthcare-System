using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Healthcare_System.Models;

namespace UnitTesting
{
    [TestClass]
    public class LoginTesting
    {
        [TestMethod]
        public void TestLoginService()
        {
            //LoginService ls = new LoginService();

            string[] staffIDs = { "2" };//, "1", "grberfsgrt" };
            string[] passwords = { "111" };//, "abc", " " };
            string[] roles = { "Nurse" };
            bool[] results = { true };//, true, false };

            for (int i = 0; i < staffIDs.Length; i++)
            {
                LoginService ls = new LoginService();
                Staff staff = new Staff();
                staff.StaffID = staffIDs[i];
                staff.Password = passwords[i];
                staff.Role = roles[i];
                bool actResult = ls.Login(staff);
                Assert.AreEqual(actResult, results[i]);
            }
        }
    }
}
