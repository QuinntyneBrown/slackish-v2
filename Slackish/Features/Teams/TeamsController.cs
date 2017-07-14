using MediatR;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Slackish.Features.Core;

namespace Slackish.Features.Teams
{
    [Authorize]
    [RoutePrefix("api/teams")]
    public class TeamController : ApiController
    {
        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(AddOrUpdateTeamCommand.Response))]
        public async Task<IHttpActionResult> Add(AddOrUpdateTeamCommand.Request request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(AddOrUpdateTeamCommand.Response))]
        public async Task<IHttpActionResult> Update(AddOrUpdateTeamCommand.Request request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }
        
        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(GetTeamsQuery.Response))]
        public async Task<IHttpActionResult> Get()
        {
            var request = new GetTeamsQuery.Request();
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(GetTeamByIdQuery.Response))]
        public async Task<IHttpActionResult> GetById([FromUri] GetTeamByIdQuery.Request request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(RemoveTeamCommand.Response))]
        public async Task<IHttpActionResult> Remove([FromUri] RemoveTeamCommand.Request request)
        {
            request.TenantUniqueId = Request.GetTenantUniqueId();
            return Ok(await _mediator.Send(request));
        }

        protected readonly IMediator _mediator;
    }
}
