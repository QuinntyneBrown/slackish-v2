using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;
using static Slackish.Features.Conversations.ConversationApiModel;

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
        {
            var results = await _mediator.SendAsync(new GetByCurrentProfileRequest(User.Identity.Name));

            return Ok(results.Select(x => FromConversation(x)).ToList());
        }
        
        private IMediator _mediator;
    }
}
