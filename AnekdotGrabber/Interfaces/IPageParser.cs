using AnekdotGrabber.Model;
using System.Collections.Generic;

namespace AnekdotGrabber.Interfaces
{
    public interface IPageParser
    {
        /// <summary>
        /// Split page to stories
        /// </summary>
        /// <param name="page">HTML Page contents</param>
        /// <returns>list of stories found on the page</returns>
        IList<Story> ParsePage(string page);
    }
}
