using MediatR;
using System.Web.Http;

namespace Slackish.Controllers
{
    [RoutePrefix("api/profile")]
    public class ProfileController
    {
        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;
    }
}
