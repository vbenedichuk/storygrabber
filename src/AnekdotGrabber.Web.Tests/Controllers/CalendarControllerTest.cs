using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnekdotGrabber.Test.Mocks;
using AnekdotGrabber.Model;
using AnekdotGrabber.Web.Controllers.Api;
using System.Collections.Generic;

namespace AnekdotGrabber.Web.Tests.Controllers
{
    [TestClass]
    public class CalendarControllerTest
    {
        DBContextMock ctx;

        [TestInitialize()]
        public void Startup()
        {
            ctx = new DBContextMock(
                new Story[]
                {
                    new Story() { Id = 1, Date = new DateTime(2016,02,23), Text="Test 1" },
                    new Story() { Id = 2, Date = new DateTime(2016,02,23), Text="Test 2" },
                    new Story() { Id = 3, Date = new DateTime(2016,02,21), Text="Test 3" },
                    new Story() { Id = 1, Date = new DateTime(2010,02,23), Text="Test 4" },
                    new Story() { Id = 2, Date = new DateTime(2010,02,23), Text="Test 5" },
                    new Story() { Id = 3, Date = new DateTime(2010,02,21), Text="Test 6" },
                    new Story() { Id = 1, Date = new DateTime(2010,02,23), Text="Test 7" },
                    new Story() { Id = 2, Date = new DateTime(2010,02,23), Text="Test 8" },
                    new Story() { Id = 3, Date = new DateTime(2010,02,21), Text="Test 9" },
                    new Story() { Id = 1, Date = new DateTime(2011,01,23), Text="Test 7" },
                    new Story() { Id = 2, Date = new DateTime(2011,02,23), Text="Test 8" },
                    new Story() { Id = 3, Date = new DateTime(2011,03,21), Text="Test 9" },
                });
        }
        
        [TestMethod]
        public void TestYears()
        {
            CalendarController controller = new CalendarController(ctx);
            List<int> testList = new List<int>(controller.Get());
            Assert.AreEqual(3, testList.Count);
            Assert.AreEqual(2010, testList[0]);
            Assert.AreEqual(2011, testList[1]);
            Assert.AreEqual(2016, testList[2]);
        }

        [TestMethod]
        public void TestMonths()
        {
            CalendarController controller = new CalendarController(ctx);
            List<int> testList = new List<int>(controller.Get(2011));
            Assert.AreEqual(3, testList.Count);
            Assert.AreEqual(1, testList[0]);
            Assert.AreEqual(2, testList[1]);
            Assert.AreEqual(3, testList[2]);
        }

        [TestMethod]
        public void TestMonthsNone()
        {
            CalendarController controller = new CalendarController(ctx);
            List<int> testList = new List<int>(controller.Get(2012));
            Assert.AreEqual(0, testList.Count);
        }

        [TestMethod]
        public void TestDays()
        {
            CalendarController controller = new CalendarController(ctx);
            List<int> testList = new List<int>(controller.Get(2011, 03));
            Assert.AreEqual(1, testList.Count);
            Assert.AreEqual(21, testList[0]);
        }

        [TestMethod]
        public void TestDaysNone()
        {
            CalendarController controller = new CalendarController(ctx);
            List<int> testList = new List<int>(controller.Get(2011, 08));
            Assert.AreEqual(0, testList.Count);
        }
    }
}
