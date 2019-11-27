using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Healthcare_System.Models;

namespace UnitTesting
{
    [TestClass]
    public class Login
    {
        [TestMethod]
        public void TestLoginService()
        {
            LoginService ls = new LoginService();

            string[] staffIDs = { "2", "1", "grberfsgrt"};
            string[] passwords = { "1111", "abc", " "};
            string[] roles = { "Nurse", "Manager", "Consultant"};
            bool[] results = { true, true, false };//, true, false };

            for (int i = 0; i < staffIDs.Length; i++)
            {
                //  LoginService ls = new LoginService();
                Staff staff = new Staff();
                staff.StaffID = staffIDs[i];
                staff.Password = passwords[i];
                staff.Role = roles[i];
                bool actResult = ls.Login(ref staff);
                Assert.AreEqual(actResult, results[i]);
            }
        }
    }
}