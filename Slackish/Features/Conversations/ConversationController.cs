using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Slackish.Features.Conversations
{
    [Authorize]
    [RoutePrefix("api/conversation")]
    public class ConversationController: ApiController
    {
        public ConversationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ResponseType(typeof(List<ConversationApiModel>))]
        public async Task<IHttpActionResult> GetByCurrentProfile()
            => Ok(await _mediator.SendAsync(new GetByCurrentProfileQuery.GetByCurrentProfileRequest(User.Identity.Name)));
        
        private IMediator _mediator;
    }
}
