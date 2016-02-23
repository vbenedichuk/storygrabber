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
            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> responseTask = httpClient.GetAsync(requestUrl);
            responseTask.Wait();
            if(responseTask.Result.IsSuccessStatusCode)
            {
                Task<string> result = responseTask.Result.Content.ReadAsStringAsync();
                result.Wait();
                return result.Result;
            }
            else
            {
                throw new UnableToGrabPageException(responseTask.Result.StatusCode, requestUrl);
            }
        }
    }
}
