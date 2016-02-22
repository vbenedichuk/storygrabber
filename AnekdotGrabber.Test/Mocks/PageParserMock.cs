using AnekdotGrabber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnekdotGrabber.Model;

namespace AnekdotGrabber.Test.Mocks
{
    public class PageParserMock : IPageParser
    {
        private int count;
        public PageParserMock(int count)
        {
            this.count = count;
        }
        public IList<Story> ParsePage(string page)
        {
            IList<Story> result = new List<Story>();
            for(int i = 0; i <count; i++)
            {
                result.Add(new Story()
                {
                    Text = i.ToString()                    
                });
            }
            return result;
        }
    }
}
