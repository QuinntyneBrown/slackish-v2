using MediatR;
using Slackish.Features.Core;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Slackish.Features.Conversations
{
    [Authorize]
    [RoutePrefix("api/conversations")]
    public class ConversationsController: BaseApiController
    {
        public ConversationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ResponseType(typeof(GetByCurrentProfileQuery.Response))]
        public async Task<IHttpActionResult> GetByCurrentProfile()
            => Ok(await _mediator.Send(new GetByCurrentProfileQuery.Request() { TenantUniqueId = TenantUniqueId, Username = Username }));
        
        private readonly IMediator _mediator;
    }
}
