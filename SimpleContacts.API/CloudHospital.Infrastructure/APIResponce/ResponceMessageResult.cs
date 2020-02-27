using System.Net;

namespace SimpleContacts.Infrastructure.APIResponce
{
    public class ResponseMessageResult<TEntity> : BaseResponseMessageResult
    {
        public TEntity Content { get; set; }

        public ResponseMessageResult()
        {
            StatusCode = HttpStatusCode.OK;
        }

        public ResponseMessageResult(HttpStatusCode statusCode, TEntity content, string message = null) : base(statusCode, message)
        {
            Content = content;
        }

        public void SetContent(TEntity content, string message = null)
        {
            Content = content;
            Message = message ?? Message;
        }
    }
}
