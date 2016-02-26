using AnekdotGrabber.Data;
using AnekdotGrabber.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnekdotGrabber
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                AnekdotRuGrabber grabber = new AnekdotRuGrabber(new PageGrabber(), new AnekdotRuPageParser(), new AppDBContext());
                grabber.GrabIt(DateTime.Now.AddMonths(-4), DateTime.Now);
            }
            catch(UnableToGrabPageException unableToGrabEx)
            {
                NLog.Logger logger = NLog.LogManager.GetLogger("Program");
                logger.Error("Unable to grab page {0} statusCode: {1}", unableToGrabEx.Url, unableToGrabEx.StatusCode);
            }
            catch (Exception ex)
            {
                NLog.Logger logger = NLog.LogManager.GetLogger("Program");
                logger.Fatal(ex);
            }
        }
    }
}
