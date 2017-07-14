using MediatR;
using Slackish.Features.Core;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Slackish.Features.Profiles
{    
    [Authorize]
    [RoutePrefix("api/profiles")]
    public class ProfilesController: BaseApiController
    {
        public ProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getOtherProfiles")]
        [ResponseType(typeof(GetOtherProfilesQuery.Response))]
        public async Task<IHttpActionResult> GetOtherProfiles()
            => Ok(await _mediator.Send(new GetOtherProfilesQuery.Request() { Username = Username, TenantUniqueId = TenantUniqueId }));

        [HttpGet]
        [Route("getCurrentProfile")]
        [ResponseType(typeof(GetCurrentProfileQuery.Response))]
        public async Task<IHttpActionResult> GetCurrentProfile()
            => Ok(await _mediator.Send(new GetCurrentProfileQuery.Request() { Username = Username, TenantUniqueId = TenantUniqueId }));

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(RegisterCommand.Request request) {
            await _mediator.Send(request);
            return Ok();
        }

        private readonly IMediator _mediator;
    }
}
