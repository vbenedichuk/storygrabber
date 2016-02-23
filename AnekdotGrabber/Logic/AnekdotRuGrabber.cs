﻿using AnekdotGrabber.Interfaces;
using AnekdotGrabber.Model;
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
        ILogWrapper logWrapper;

        private const string SITE_URL_TEMPLATE = "http://www.anekdot.ru/release/story/day/{0:yyyy-MM-dd}/";

        public AnekdotRuGrabber(IPageGrabber pageGrabber, IPageParser pageParser, IAppDbContext context, ILogWrapper logWrapper)
        {
            this.pageGrabber = pageGrabber;
            this.pageParser = pageParser;
            this.context = context;
            this.logWrapper = logWrapper;
        }

        public void GrabIt(DateTime startDateTime, DateTime endDateTime)
        {            
            if(startDateTime > endDateTime)
            {
                logWrapper.Error("{0}  Start Date:{1} End Date:{2}", AppResources.StartDateShouldBeLessOrEqualToEndDate, startDateTime, endDateTime);
                throw new ArgumentException(AppResources.StartDateShouldBeLessOrEqualToEndDate);
            }
            DateTime currentDate = startDateTime.Date;
            DateTime endDate = endDateTime.Date;
            while(currentDate <= endDate)
            {
                
                logWrapper.Info("GET: {0}", currentDate);
                Story[] storiesToDelete = context.Stories.Where<Story>(x => x.Date == currentDate).ToArray<Story>();
                context.Stories.RemoveRange(storiesToDelete);
                context.SaveChanges();

                string pageContents = pageGrabber.GetPageContents(String.Format(SITE_URL_TEMPLATE, currentDate));
                IList<Story> stories = pageParser.ParsePage(pageContents);                
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
