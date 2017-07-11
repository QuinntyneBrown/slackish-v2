using Microsoft.Owin;
using System.Threading.Tasks;

namespace Slackish.Features.Core
{
    public class TenantMiddleware : OwinMiddleware
    {
        public TenantMiddleware(OwinMiddleware next)
            : base(next) { }

        public override async Task Invoke(IOwinContext context)
        {            
            var values = context.Request.Headers.GetValues("Tenant");
            if (values != null)
            {
                context.Environment.Add("Tenant", ((string[])(values))[0]);
            }            
            await Next.Invoke(context);
        }
    }
}