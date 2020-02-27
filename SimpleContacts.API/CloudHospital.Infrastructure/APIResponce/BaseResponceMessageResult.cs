using System.Net;

namespace SimpleContacts.Infrastructure.APIResponce
{
    public class BaseResponseMessageResult
    {
        public HttpStatusCode? StatusCode { get; set; }
        public string Message { get; set; }

        public BaseResponseMessageResult()
        {
            StatusCode = HttpStatusCode.OK;
        }

        public BaseResponseMessageResult(HttpStatusCode statusCode, string message = null) : this()
        {
            StatusCode = statusCode;
            Message = message;
        }

        public void SetStatus(HttpStatusCode statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? Message;
        }
    }
}
