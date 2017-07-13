using MediatR;
using Slackish.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Slackish.Features.Conversations
{
    [Authorize]
    [RoutePrefix("api/conversations")]
    public class ConversationsController: ApiController
    {
        public ConversationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ResponseType(typeof(List<ConversationApiModel>))]
        public async Task<IHttpActionResult> GetByCurrentProfile()
        {            
            var request = new GetByCurrentProfileQuery.Request(User.Identity.Name);
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }
        
        private readonly IMediator _mediator;
    }
}
