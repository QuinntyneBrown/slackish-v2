using MediatR;
using Slackish.Features.Conversations;
using System.Threading.Tasks;
using System.Web.Http;

namespace Slackish.Controllers
{
    [RoutePrefix("api/conversation")]
    public class ConversationController: ApiController
    {
        public ConversationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        public async Task<IHttpActionResult> GetByCurrentProfile()
        {            
            return Ok(await _mediator.SendAsync(new GetByCurrentProfileQuery(User.Identity.Name)));
        }
        
        private IMediator _mediator;
    }
}
