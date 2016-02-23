using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AnekdotGrabber.Test.Mocks;
using AnekdotGrabber.Logic;

namespace AnekdotGrabber.Test
{
    [TestClass]
    public class AnekdotRuGrabberTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DeploymentItem("AnekdotGrabber.Test\\TestGrabIt1Counts.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "|DataDirectory|\\TestGrabIt1Counts.xml",
                   "Row",
                    DataAccessMethod.Sequential)]
        public void TestGrabIt1()
        {
            int count = Int32.Parse((string)TestContext.DataRow["Count"]);            
            int result = Int32.Parse((string)TestContext.DataRow["Result"]);

            IList<string> resultUrls = new List<string>();
            PageGrabberMock pageGrabber = new PageGrabberMock(resultUrls);
            PageParserMock pageParser = new PageParserMock(count);
            DBContextMock dbContextMock = new DBContextMock();
            AnekdotRuGrabber grabber = new AnekdotRuGrabber(pageGrabber, pageParser, dbContextMock);
            grabber.GrabIt(new DateTime(2016, 02, 22, 10, 03, 12));
            Assert.AreEqual(1, resultUrls.Count);
            Assert.AreEqual(2, dbContextMock.SaveChangesCount);
            Assert.AreEqual(result, dbContextMock.Stories.Local.Count);
            Assert.AreEqual("http://www.anekdot.ru/release/story/day/2016-02-22/", resultUrls[0]);
        }

        [TestMethod]
        [DeploymentItem("AnekdotGrabber.Test\\TestGrabIt2Counts.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "|DataDirectory|\\TestGrabIt2Counts.xml",
                   "Row",
                    DataAccessMethod.Sequential)]
        public void TestGrabIt2()
        {
            int count = Int32.Parse((string)TestContext.DataRow["Count"]);
            int result = Int32.Parse((string)TestContext.DataRow["Result"]);

            IList<string> resultUrls = new List<string>();
            PageGrabberMock pageGrabber = new PageGrabberMock(resultUrls);
            PageParserMock pageParser = new PageParserMock(count);
            DBContextMock dbContextMock = new DBContextMock();
            AnekdotRuGrabber grabber = new AnekdotRuGrabber(pageGrabber, pageParser, dbContextMock);
            grabber.GrabIt(new DateTime(2016, 02, 16, 10, 03, 12), new DateTime(2016, 02, 22, 10, 03, 12));
            Assert.AreEqual(14, dbContextMock.SaveChangesCount);
            Assert.AreEqual(result, dbContextMock.Stories.Local.Count);
            Assert.AreEqual(7, resultUrls.Count);
            Assert.AreEqual("http://www.anekdot.ru/release/story/day/2016-02-16/", resultUrls[0]);
            Assert.AreEqual("http://www.anekdot.ru/release/story/day/2016-02-17/", resultUrls[1]);
            Assert.AreEqual("http://www.anekdot.ru/release/story/day/2016-02-18/", resultUrls[2]);
            Assert.AreEqual("http://www.anekdot.ru/release/story/day/2016-02-19/", resultUrls[3]);
            Assert.AreEqual("http://www.anekdot.ru/release/story/day/2016-02-20/", resultUrls[4]);
            Assert.AreEqual("http://www.anekdot.ru/release/story/day/2016-02-21/", resultUrls[5]);
            Assert.AreEqual("http://www.anekdot.ru/release/story/day/2016-02-22/", resultUrls[6]);
        }

        [TestMethod]
        public void TestGrabItFail()
        {
            IList<string> resultUrls = new List<string>();
            PageGrabberMock pageGrabber = new PageGrabberMock(resultUrls);
            PageParserMock pageParser = new PageParserMock(0);
            DBContextMock dbContextMock = new DBContextMock();
            AnekdotRuGrabber grabber = new AnekdotRuGrabber(pageGrabber, pageParser, dbContextMock);
            try {
                grabber.GrabIt(new DateTime(2016, 02, 22, 10, 03, 12), new DateTime(2016, 02, 16, 10, 03, 12));
                Assert.Fail();
            }
            catch(ArgumentException ex)
            {
                Assert.AreEqual(ex.Message, "Start Date should be less or equal to End Date");
            }
        }
    }
}
