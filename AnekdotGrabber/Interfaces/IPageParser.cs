using AnekdotGrabber.Model;
using System.Collections.Generic;

namespace AnekdotGrabber.Interfaces
{
    public interface IPageParser
    {
        IList<Story> ParsePage(string page);
    }
}
