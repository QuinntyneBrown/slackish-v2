using System.Web.Http.Filters;
using Slackish.Utilities;
using Microsoft.Practices.Unity;

namespace Slackish.Filters
{
    public class HandleErrorAttribute : ExceptionFilterAttribute
    {
        public HandleErrorAttribute()
        {

        }

        public override void OnException(HttpActionExecutedContext context)
        {

        }

        [Dependency]
        public ILogger _logger { get; set; }
    }
}


