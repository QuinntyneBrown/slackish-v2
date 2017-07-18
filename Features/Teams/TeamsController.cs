using MediatR;
using Slackish.Features.Core;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Slackish.Features.Teams
{
    [Authorize]
    [RoutePrefix("api/teams")]
    public class TeamController : BaseApiController
    {
        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getCurrentTeam")]
        [ResponseType(typeof(GetCurrentTeamQuery.Response))]
        public async Task<IHttpActionResult> GetCurrentTeam()
            => Ok(await _mediator.Send(new GetCurrentTeamQuery.Request() { Username = Username, TenantUniqueId = TenantUniqueId }));

        [HttpPost]
        [Route("setCurrentTeam")]
        [ResponseType(typeof(SetCurrentTeamCommand.Response))]
        public async Task<IHttpActionResult> SetCurrentTeam(SetCurrentTeamCommand.Request request)
        {
            request.Username = Username;
            request.TenantUniqueId = TenantUniqueId;
            return Ok(await _mediator.Send(request));
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateTeamCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateTeamCommand.Request request)
        {
            request.TenantUniqueId = TenantUniqueId;
            return Ok(await _mediator.Send(request));
        }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateTeamCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateTeamCommand.Request request)
        {
            request.TenantUniqueId = TenantUniqueId;
            return Ok(await _mediator.Send(request));
        }
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetTeamsQuery.Response))]
        public async Task<IHttpActionResult> Get()
        {
            var request = new GetTeamsQuery.Request() { TenantUniqueId = TenantUniqueId };            
            return Ok(await _mediator.Send(request));
        }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetTeamByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri] GetTeamByIdQuery.Request request)
        {
            request.TenantUniqueId = TenantUniqueId;
            return Ok(await _mediator.Send(request));
        }

        [Route("getByName")]
        [HttpGet]
        [ResponseType(typeof(GetTeamByNameQuery.Response))]
        public async Task<IHttpActionResult> GetByName([FromUri] GetTeamByNameQuery.Request request)
        {
            request.TenantUniqueId = TenantUniqueId;
            return Ok(await _mediator.Send(request));
        }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveTeamCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri] RemoveTeamCommand.Request request)
        {
            request.TenantUniqueId = TenantUniqueId;
            return Ok(await _mediator.Send(request));
        }

        protected readonly IMediator _mediator;
    }
}
