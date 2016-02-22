using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AnekdotGrabber.Test.Mocks;
using AnekdotGrabber.Logic;
using System.Resources;
using AnekdotGrabber.Model;

namespace AnekdotGrabber.Test
{
    [TestClass]
    public class AnekdotRuPageParserTest
    {
        [TestMethod]
        public void TestParseEmptyPage()
        {
            AnekdotRuPageParser parser = new AnekdotRuPageParser();
            parser.ParsePage("");
        }

        [TestMethod]
        public void TestParseRealPage1()
        {
            AnekdotRuPageParser parser = new AnekdotRuPageParser();
            IList<Story> stories = parser.ParsePage(TestPages._2014_03_05);
            Assert.AreEqual(19, stories.Count);
        }

        [TestMethod]
        public void TestParseRealPage2()
        {
            AnekdotRuPageParser parser = new AnekdotRuPageParser();
            IList<Story> stories = parser.ParsePage(TestPages._2015_09_15);
            Assert.AreEqual(18, stories.Count);
        }

        [TestMethod]
        public void TestParseRealPage3()
        {
            AnekdotRuPageParser parser = new AnekdotRuPageParser();
            IList<Story> stories = parser.ParsePage(TestPages._2016_02_17);
            Assert.AreEqual(18, stories.Count);
        }
    }
}
