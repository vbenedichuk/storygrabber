using AnekdotGrabber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnekdotGrabber.Logic
{
    public class PageGrabber : IPageGrabber
    {
        public string GetPageContents(string requestUrl)
        {
            var httpClient = new HttpClient();
            var responseTask = httpClient.GetAsync(requestUrl);
            var response = responseTask.Result;
            if(response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();
                return result.Result;
            }
            else
            {
                throw new UnableToGrabPageException(responseTask.Result.StatusCode, requestUrl);
            }
        }
    }
}
