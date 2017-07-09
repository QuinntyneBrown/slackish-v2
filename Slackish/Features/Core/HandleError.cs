using System.Net.Http;
using System.Web.Http.Filters;
using static System.Net.HttpStatusCode;

namespace Slackish.Features.Core
{
    public class HandleErrorAttribute : ExceptionFilterAttribute
    {
        public HandleErrorAttribute(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("Error");
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateResponse(BadRequest, context.Exception.Message);
        }

        protected readonly ILogger _logger;
    }
}