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
            AnekdotRuGrabber grabber = new AnekdotRuGrabber(new PageGrabber(), new AnekdotRuPageParser(), new AppDBContext());
            grabber.GrabIt(DateTime.Now.AddMonths(-1), DateTime.Now);
        }
    }
}
