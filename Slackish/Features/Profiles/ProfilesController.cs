using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

using static Slackish.Features.Profiles.GetOtherProfilesQuery;

namespace Slackish.Features.Profiles
{    
    [RoutePrefix("api/profiles")]
    public class ProfilesController: ApiController
    {
        public ProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getByOtherProfileId")]
        public async Task<IHttpActionResult> GetByOtherProfileId(int otherProfileId)
            => Ok(await _mediator.Send(new GetOtherProfilesRequest() { OtherProfileId = otherProfileId }));

        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register(RegisterRequest request)
            => Ok(await _mediator.Send(request));

        protected readonly IMediator _mediator;
    }
}
