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
    public class CalendarController : ApiController //TODO: Optimize
    {
        IApplicationDbContext ctx;

        public CalendarController(IApplicationDbContext ctx) : base()
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// GET: api/Calendar
        /// Возвращает список лет, за которые есть статьи. Упорядоченный по возрастанию.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> Get()
        {
            return ctx.Stories.Select<Story, int>(x => x.Date.Year).Distinct<int>().OrderBy<int, int>(x => x);
        }

        /// <summary>
        /// Возвращает список месяцев в году, за которые есть статьи. Упорядоченный по возрастанию.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public IEnumerable<int> Get(int year)
        {
            return ctx.Stories.Where(x => x.Date.Year == year).Select<Story, int>(x => x.Date.Month).Distinct<int>().OrderBy<int, int>(x => x);
        }

        /// <summary>
        /// Возвращает список дней в месяце, за которые есть статьи. Упорядоченный по возрастанию.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public IEnumerable<int> Get(int year, int month)
        {
            return ctx.Stories.Where(x => x.Date.Year == year && x.Date.Month == month).Select<Story, int>(x => x.Date.Day).Distinct<int>().OrderBy<int, int>(x => x);
        }

    }
}
