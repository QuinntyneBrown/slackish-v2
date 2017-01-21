using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace Slackish.Features.Profiles
{    
    [RoutePrefix("api/profile")]
    public class ProfileController: ApiController
    {
        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getByOtherProfileId")]
        public async Task<IHttpActionResult> GetByOtherProfileId(int otherProfileId)
            => Ok(await _mediator.SendAsync(new GetOtherProfilesQuery
                .GetOtherProfilesRequest() { OtherProfileId = otherProfileId }));

        [HttpPost]
        [Route("register")]
        public async Task<IHttpActionResult> Register(RegisterRequest request)
            => Ok(await _mediator.SendAsync(request));

        protected readonly IMediator _mediator;
    }
}
