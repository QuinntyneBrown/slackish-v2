using Microsoft.Owin;
using System.Threading.Tasks;
using System.Web.Http;

namespace Slackish.Features.Core
{
    public class TenantMiddleware : OwinMiddleware
    {
        public TenantMiddleware(OwinMiddleware next)
            : base(next) { }

        public override async Task Invoke(IOwinContext context)
        {
            //var SlackishDbContext = (SlackishDbContext)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(SlackishDbContext));

            //var values = context.Request.Headers.GetValues("Tenant");
            //if (values != null)
            //{
            //    context.Environment.Add("Tenant", ((string[])(values))[0]);
            //}

            context.Environment.Add("Tenant", "a70560f6-b4a7-46d2-a881-043c7f460e6b");

            await Next.Invoke(context);
        }
    }
}