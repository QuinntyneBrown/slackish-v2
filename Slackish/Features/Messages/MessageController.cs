using MediatR;
using System.Web.Http;

namespace Slackish.Featrues.Messages
{
    [RoutePrefix("api/message")]
    public class MessageController: ApiController
    {
        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("send")]
        public IHttpActionResult Send()
        {
            return Ok();
        }

        private IMediator _mediator;
    }
}
