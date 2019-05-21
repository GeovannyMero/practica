using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Practica.Tests.Controllers
{
    [TestClass]
    public class JsonDemoControllerTest
    {
        [TestMethod]
        public void WelcomeNote()
        {
            JsonDemoController controller = new JsonDemoController();

            JsonResult result = controller.WelcomeNote();
            string msg = Convert.ToString(result.Data);
            // Assert  
            Assert.AreEqual("Welcome to the User", msg);
        }
    }
}
