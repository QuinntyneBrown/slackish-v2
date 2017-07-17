using MediatR;
using Slackish.Features.Core;
using System.Web.Http;
using System.Web.Http.Description;

namespace Slackish.Features.Messages
{
    [Authorize]
    [RoutePrefix("api/messages")]
    public class MessagesController: BaseApiController
    {
        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get")]
        [ResponseType(typeof(GetMessagesQuery.Response))]
        public IHttpActionResult Get()
        {
            
            return Ok(_mediator.Send(new GetMessagesQuery.Request() { TenantUniqueId = TenantUniqueId, Username = Username }));
        }

        [HttpPost]
        [Route("send")]
        [ResponseType(typeof(SendMessageAndReplyCommand.Response))]
        public IHttpActionResult Send(SendMessageAndReplyCommand.Request request)
        {            
            _mediator.Send(request);
            return Ok();
        }
        
        private readonly IMediator _mediator;
    }
}
