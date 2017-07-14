using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace Slackish.Features.Core
{
    public class BaseApiController: ApiController
    {
        public string Username {
            get { return User.Identity.Name; }
        }

        public Guid TenantUniqueId
        {
            get
            {
                if(User.Identity.IsAuthenticated == false)
                {
                    return new Guid(((string[])Request.Headers.GetValues("tenant"))[0]);
                }

                var claim = (User as ClaimsPrincipal).Claims.Single(x => x.Type == "tenant");
                return new Guid(claim.Value);
            }
        }
    }
}