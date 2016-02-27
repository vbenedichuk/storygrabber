using System;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Permissions;

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

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Url", url);
            info.AddValue("StatusCode", StatusCode);
        }

    }
}