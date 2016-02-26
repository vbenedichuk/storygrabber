using AnekdotGrabber.Interfaces;
using AnekdotGrabber.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnekdotGrabber.Logic
{
    public class AnekdotRuPageParser : IPageParser
    {
        public IList<Story> ParsePage(string page)
        {
            var result = new List<Story>();
            var document = new HtmlDocument();
            document.LoadHtml(page);
            var nodes = document.DocumentNode.SelectNodes("//div[@class='topicbox']");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var textNode = node.SelectSingleNode(".//div[@class='text']");
                    if (textNode != null)
                    {
                        Story story = new Story()
                        {
                            Text = textNode.InnerHtml
                        };
                        result.Add(story);
                    }
                }
            }
            return result;
        }
    }
}
