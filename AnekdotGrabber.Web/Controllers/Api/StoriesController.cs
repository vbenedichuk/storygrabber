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
        IApplicationDbContext ctx;
        public StoriesController(IApplicationDbContext ctx) : base()
        {
            this.ctx = ctx;
        }

        // GET: api/Stories
        public IEnumerable<Story> Get(DateTime date)
        {
            return ctx.Stories.Where<Story>(x => x.Date == date.Date);
        }

        // GET: api/Stories/5
        public Story Get(int id)
        {            
            return ctx.Stories.FirstOrDefault<Story>(x => x.Id == id);
        }
              
    }
}
