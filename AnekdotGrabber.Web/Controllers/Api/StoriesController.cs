using AnekdotGrabber.Model;
using AnekdotGrabber.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AnekdotGrabber.Web.Controllers.Api
{
    public class StoriesController : ApiController
    {
        public StoriesController() : base()
        {

        }

        // GET: api/Stories
        public IEnumerable<Story> Get(DateTime date)
        {

            ApplicationDbContext ctx = new ApplicationDbContext();
            return ctx.Stories.Where<Story>(x => x.Date == date.Date);
        }

        // GET: api/Stories/5
        public Story Get(int id)
        {
            ApplicationDbContext ctx = new ApplicationDbContext();
            return ctx.Stories.FirstOrDefault<Story>(x => x.Id == id);
            //return "value";
        }
              
    }
}
