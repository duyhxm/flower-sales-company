using Microsoft.VisualStudio.TestTools.UnitTesting;
using PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Tests
{
    [TestClass()]
    public class LoginFormTests
    {
        [TestMethod()]
        public void StartServiceBusHostTest()
        {
            LoginForm loginForm = new LoginForm();
            loginForm.RunServiceBusHost();
        }
    }
}