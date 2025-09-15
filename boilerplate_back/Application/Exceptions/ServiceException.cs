using System.Net;

namespace Application.Exceptions
{
    public class ServiceException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public ServiceException(HttpStatusCode code, string message) : base(message)
        {
            StatusCode = code;
        }
    }
}
