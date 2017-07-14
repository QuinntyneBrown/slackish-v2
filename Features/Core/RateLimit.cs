
using Microsoft.Practices.Unity;
using Slackish.Data;
using System;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using static System.Net.HttpStatusCode;

namespace Slackish.Features.Core
{
    public class RateLimitAttribute : ActionFilterAttribute
    {
        public RateLimitAttribute(int maxPerHour = 150)
        {
            _maxRequestsHour = maxPerHour;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //var request = actionContext.Request;
            //var ip = GetClientIp(request);

            //if (ip == null)
            //    actionContext.Response = actionContext.Request.CreateResponse(Forbidden, "The client ip couldn't be found");

            //var requests = _context.Ips.GetRequestsByIpAndHourQuery(DateTime.Now, ip);

            //if (requests >= _maxRequestsHour)
            //    actionContext.Response = actionContext.Request.CreateResponse(Forbidden, "Quota Exceeded");

            //if (requests < _maxRequestsHour)
            //    _context.Ips.Increment(DateTime.Now, ip);
        }

        private string GetClientIp(HttpRequestMessage request)
        {
            //if (request.Properties.ContainsKey("MS_HttpContext"))
            //{
            //    return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            //}
            //else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            //{
            //    RemoteEndpointMessageProperty prop;
            //    prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
            //    return prop.Address;
            //}
            //else
            //{
            //    return null;
            //}

            throw new NotImplementedException();
        }

        [Dependency]
        public SlackishContext _context { get; set; }

        private int _maxRequestsHour;
    }
}
