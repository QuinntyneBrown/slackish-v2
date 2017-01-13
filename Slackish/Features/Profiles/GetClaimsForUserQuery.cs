using MediatR;
using Slackish.Authentication;
using System;
using System.Threading.Tasks;

namespace Slackish.Features.Profiles
{
    public class GetClaimsForUserQuery : IAsyncRequestHandler<GetClaimsForUserRequest, GetClaimsForUserResponse>
    {
        public Task<GetClaimsForUserResponse> Handle(GetClaimsForUserRequest message)
        {
            throw new NotImplementedException();
        }


    }
}
