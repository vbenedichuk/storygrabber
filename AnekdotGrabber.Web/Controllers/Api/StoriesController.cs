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

        /// <summary>
        /// GET: api/Stories
        /// Возвращает список историй за дату
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public IEnumerable<Story> Get(DateTime date)
        {
            return ctx.Stories.Where<Story>(x => x.Date == date.Date);
        }

        /// <summary>
        /// GET: api/Stories/5
        /// Возвращает историю по ID
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public Story Get(int id)
        {            
            return ctx.Stories.FirstOrDefault<Story>(x => x.Id == id);
        }
              
    }
}
