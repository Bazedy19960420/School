using System.Net;

namespace School.core.Bases
{
    public class Response<T>
    {
        #region Properties
        public bool Succeeded { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; } = default!;
        public HttpStatusCode StatusCode { get; set; }
        public object Meta { get; set; } = default!;
        public string[] Errors { get; set; } = Array.Empty<string>();
        #endregion

        #region Constructors
        public Response()
        {

        }
        public Response(T data, string message)
        {
            Succeeded = true;
            Data = data;
            Message= message;
        }
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }
        #endregion
    }
}
