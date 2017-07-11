using MediatR;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

using static Slackish.Features.Messages.SendMessageCommand;

namespace Slackish.Features.Messages
{
    [Authorize]
    [RoutePrefix("api/messages")]
    public class MessagesController: ApiController
    {
        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IHttpActionResult> Send(SendMessageRequest request)
        {
            var identity = User.Identity as ClaimsIdentity;

            return Ok(await _mediator.Send(request));
        }
        
        private readonly IMediator _mediator;
    }
}
