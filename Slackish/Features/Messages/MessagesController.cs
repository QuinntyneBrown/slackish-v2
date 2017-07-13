using MediatR;
using System.Web.Http;

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
        public IHttpActionResult Send(SendMessageAndReplyCommand.Request request)
        {            
            _mediator.Send(request);
            return Ok();
        }
        
        private readonly IMediator _mediator;
    }
}
