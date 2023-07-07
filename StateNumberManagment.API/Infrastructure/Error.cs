using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace StateNumberManagment.API.Infrastructure
{
    public class Error : ProblemDetails
    {
        private HttpContext _context;
        private Exception _exception;

        public string TraceId;
        public LogLevel LogLevel;

        public Error(HttpContext context, Exception ex)
        {
            _context = context;
            _exception = ex;

            TraceId = context.TraceIdentifier;

            HandleException((dynamic)ex);
        }

        private void HandleException(Exception ex)
        {
            Status = 500;
            Title = ex.Message;
            Status = (int)HttpStatusCode.InternalServerError;
            LogLevel = LogLevel.Error;
            Instance = _context.Request.Path;
        }
    }
}
