using MediatR;
using Slackish.Features.Core;
using System.Threading.Tasks;
using System.Web.Http;

namespace Slackish.Features.Profiles
{    
    [RoutePrefix("api/profiles")]
    public class ProfilesController: BaseApiController
    {
        public ProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getByOtherProfileId")]
        public async Task<IHttpActionResult> GetByOtherProfileId(int otherProfileId)
            => Ok(await _mediator.Send(new GetOtherProfilesQuery.Request() { OtherProfileId = otherProfileId }));

        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register(RegisterCommand.Request request) {
            await _mediator.Send(request);
            return Ok();
        }

        private readonly IMediator _mediator;
    }
}
