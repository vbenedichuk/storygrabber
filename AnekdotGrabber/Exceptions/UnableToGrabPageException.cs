using System;
using System.Net;
using System.Runtime.Serialization;

namespace AnekdotGrabber.Logic
{
    [Serializable]
    public class UnableToGrabPageException : Exception
    {
        private HttpStatusCode statusCode;
        public HttpStatusCode StatusCode { get { return statusCode; } }

        public UnableToGrabPageException(HttpStatusCode statusCode) : base(statusCode.ToString())
        {
            this.statusCode = statusCode;
        }

    }
}