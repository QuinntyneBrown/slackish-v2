using MediatR;
using Slackish.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

using static Slackish.Features.Conversations.GetByCurrentProfileQuery;

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
            var request = new GetByCurrentProfileRequest(User.Identity.Name);
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }
        
        private readonly IMediator _mediator;
    }
}
