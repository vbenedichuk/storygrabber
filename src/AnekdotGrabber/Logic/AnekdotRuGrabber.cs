using AnekdotGrabber.Interfaces;
using AnekdotGrabber.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnekdotGrabber.Logic
{
    public class AnekdotRuGrabber
    {
        private IPageGrabber pageGrabber;
        private IPageParser pageParser;
        private IAppDbContext context;
        private Logger logger = LogManager.GetLogger("AnekdotRuGrabber");

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
                throw new ArgumentException(AppResources.StartDateShouldBeLessOrEqualToEndDate);
            }
            var currentDate = startDateTime.Date;
            var endDate = endDateTime.Date;
            while(currentDate <= endDate)
            {
                logger.Info("GET: {0}", currentDate);
                var storiesToDelete = context.Stories.Where<Story>(x => x.Date == currentDate).ToArray<Story>();
                context.Stories.RemoveRange(storiesToDelete);
                context.SaveChanges();

                var pageContents = pageGrabber.GetPageContents(String.Format(SITE_URL_TEMPLATE, currentDate));
                var stories = pageParser.ParsePage(pageContents);                
                foreach (Story story in stories)
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
