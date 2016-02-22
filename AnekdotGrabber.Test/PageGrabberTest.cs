using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnekdotGrabber.Logic;

namespace AnekdotGrabber.Test
{
    [TestClass]
    public class PageGrabberTest
    {
        [TestMethod]
        public void GetPageContentsTest()
        {
            PageGrabber grabber = new PageGrabber();
            string pageContents = grabber.GetPageContents("http://www.anekdot.ru/release/story/day/2014-03-05/");
            Assert.IsFalse(String.IsNullOrEmpty(pageContents));
            
        }
        [TestMethod]
        public void GetPageContentsTestFail()
        {
            PageGrabber grabber = new PageGrabber();
            try {
                string pageContents = grabber.GetPageContents("http://www.anekdot.ru/release/story/ds/");
                Assert.Fail();
            }
            catch (UnableToGrabPageException ex)
            {
                Assert.AreEqual("NotFound", ex.StatusCode.ToString());
            }
        }
    }
}
