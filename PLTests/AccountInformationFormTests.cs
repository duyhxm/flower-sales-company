using Microsoft.VisualStudio.TestTools.UnitTesting;
using PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace PL.Tests
{
    [TestClass()]
    public class AccountInformationFormTests
    {
        [TestMethod()]
        public void DisplayInformationTest()
        {
            AccountInformationForm.Initialize();
            AccountInformationForm form = AccountInformationForm.Instance;


            LoginInformation info = new LoginInformation();
            {
               
            };
            form.DisplayInformation(info);
        }
    }
}