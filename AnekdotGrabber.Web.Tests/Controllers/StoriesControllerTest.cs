using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnekdotGrabber.Test.Mocks;
using AnekdotGrabber.Model;
using AnekdotGrabber.Web.Controllers.Api;
using System.Collections.Generic;

namespace AnekdotGrabber.Web.Tests.Controllers
{
    [TestClass]
    public class StoriesControllerTest
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
                });
        }

        [TestMethod]
        public void TestGetByDate()
        {
            StoriesController controller = new StoriesController(ctx);            
            List<Story> testList1 = new List<Story>(controller.Get(new DateTime(2016, 02, 23)));
            Assert.AreEqual(2, testList1.Count);
            Assert.AreEqual("Test 1", testList1[0].Text);
            Assert.AreEqual("Test 2", testList1[1].Text);

            List<Story> testList2 = new List<Story>(controller.Get(new DateTime(2016, 02, 21)));
            Assert.AreEqual(1, testList2.Count);
            Assert.AreEqual("Test 3", testList2[0].Text);

            List<Story> testList3 = new List<Story>(controller.Get(new DateTime(2016, 02, 22)));
            Assert.AreEqual(0, testList3.Count);
        }

        [TestMethod]
        public void TestGetById()
        {
            StoriesController controller = new StoriesController(ctx);
            Story story1 = controller.Get(1);
            Story story2 = controller.Get(2);
            Story story3 = controller.Get(3);
            Story storyNone = controller.Get(4);

            Assert.AreEqual(1, story1.Id);
            Assert.AreEqual("Test 1", story1.Text);
            Assert.AreEqual(2, story2.Id);
            Assert.AreEqual("Test 2", story2.Text);
            Assert.AreEqual(3, story3.Id);
            Assert.AreEqual("Test 3", story3.Text);
            Assert.IsNull(storyNone);
        }        
    }
}
