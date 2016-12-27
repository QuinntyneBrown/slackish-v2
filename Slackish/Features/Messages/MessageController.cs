using MediatR;
using System.Web.Http;

namespace Slackish.Controllers
{
    [RoutePrefix("api/message")]
    public class MessageController
    {
        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private IMediator _mediator;
    }
}
