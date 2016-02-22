using AnekdotGrabber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnekdotGrabber.Test.Mocks
{
    class PageGrabberMock : IPageGrabber
    {
        private IList<string> urls;

        public PageGrabberMock(IList<string> urls)
        {
            this.urls = urls;
        }

        public string GetPageContents(string requestUrl)
        {
            this.urls.Add(requestUrl);
            return String.Empty;
        }
    }
}
