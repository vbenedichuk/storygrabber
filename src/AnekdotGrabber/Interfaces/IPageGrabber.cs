using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnekdotGrabber.Interfaces
{
    public interface IPageGrabber
    {
        /// <summary>
        /// Read page contents from the web
        /// </summary>
        /// <param name="requestUrl">Page URL</param>
        /// <returns>HTML contents</returns>
        string GetPageContents(string requestUrl);
    }
}
