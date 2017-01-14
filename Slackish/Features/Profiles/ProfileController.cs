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
        
        protected readonly IMediator _mediator;
    }
}
