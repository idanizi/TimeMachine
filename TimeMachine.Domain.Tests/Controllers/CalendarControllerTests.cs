using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeMachine.Domain.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeMachine.Domain.Controllers.Tests
{
    [TestClass()]
    public class CalendarControllerTests
    {

        #region Setup
        private CalendarController controller;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Before()
        {
            controller = new CalendarController();
        }

        [TestCleanup]
        public void After()
        {
            controller.Clear();
            controller = null;
        }
        #endregion

        [TestMethod()]
        public void GetTimeSpaceByCalendarTest()
        {
            //Arrange

            //Act
            var act = controller.GetTimeSpaceByCalendar(0);

            //Assert
            Assert.AreEqual(0, act);
        }
    }
}