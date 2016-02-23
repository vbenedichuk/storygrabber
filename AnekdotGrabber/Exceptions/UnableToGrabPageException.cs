using System;
using System.Net;
using System.Runtime.Serialization;

namespace AnekdotGrabber.Logic
{
    [Serializable]
    public class UnableToGrabPageException : Exception
    {
        private HttpStatusCode statusCode;
        private string url;
        public HttpStatusCode StatusCode { get { return statusCode; } }
        public string Url { get { return url; } }
        public UnableToGrabPageException(HttpStatusCode statusCode, string url) : base(statusCode.ToString())
        {
            this.statusCode = statusCode;
            this.url = url;
        }

    }
}