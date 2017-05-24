using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeMachine.Service.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeMachine.Service.Agents.Tests
{
    [TestClass()]
    public class GoogleCalendarAgentTests
    {


        #region Setup
        private GoogleCalendarAgent agent;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Before()
        {
            agent = new GoogleCalendarAgent();
        }

        [TestCleanup]
        public void After()
        {
            agent.Clear();
            agent = null;
        }
        #endregion

        [TestMethod()]
        public void FirstTestTest()
        {
            //Arrange

            //Act
            var act = agent.FirstTest();

            //Assert
            TestContext.WriteLine(act);
        }
    }
}