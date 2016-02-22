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
            List<Story> result = new List<Story>();

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(page);
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes("//div[@class='topicbox']");
            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    HtmlNode textNode = node.SelectSingleNode(".//div[@class='text']");
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
