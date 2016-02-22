using AnekdotGrabber.Interfaces;
using AnekdotGrabber.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnekdotGrabber.Logic
{
    public class AnekdotRuGrabber
    {
        private IPageGrabber pageGrabber;
        private IPageParser pageParser;
        private IAppDbContext context;

        private const string SITE_URL_TEMPLATE = "http://www.anekdot.ru/release/story/day/{0:yyyy-MM-dd}/";

        public AnekdotRuGrabber(IPageGrabber pageGrabber, IPageParser pageParser, IAppDbContext context)
        {
            this.pageGrabber = pageGrabber;
            this.pageParser = pageParser;
            this.context = context;
        }

        public void GrabIt(DateTime startDateTime, DateTime endDateTime)
        {            
            if(startDateTime > endDateTime)
            {
                throw new ArgumentException("Start Date should be less or equal to End Date"); //TODO: Extract to resource
            }
            DateTime currentDate = startDateTime.Date;
            DateTime endDate = endDateTime.Date;
            while(currentDate <= endDate)
            {
                Debug.WriteLine(currentDate);
                string pageContents = pageGrabber.GetPageContents(String.Format(SITE_URL_TEMPLATE, currentDate));
                IList<Story> stories = pageParser.ParsePage(pageContents);
                foreach(Story story in stories)
                {
                    
                    story.Date = currentDate;
                    context.Stories.Add(story);
                }
                context.SaveChanges();
                currentDate = currentDate.AddDays(1);
            }
        }

        public void GrabIt(DateTime grabDate)
        {
            this.GrabIt(grabDate, grabDate);
        }

    }
}
