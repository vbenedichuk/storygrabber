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
                //NLog.LogManager.Configuration.Reload();
                AnekdotRuGrabber grabber = new AnekdotRuGrabber(new PageGrabber(), new AnekdotRuPageParser(), new AppDBContext(), new LogWrapper("AnekdotRuGrabber"));
                grabber.GrabIt(DateTime.Now.AddMonths(-4), DateTime.Now);
            }
            catch(UnableToGrabPageException ex)
            {
                Console.WriteLine(String.Format(AppResources.UnableToGrabThePage, ex.StatusCode, ex.Url));
            }
        }
    }
}
