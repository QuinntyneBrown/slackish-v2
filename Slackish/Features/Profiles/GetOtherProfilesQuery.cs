using System;
using System.Threading.Tasks;
using MediatR;

namespace Slackish.Features.Profiles
{
    public class GetOtherProfilesRequest: IAsyncRequest<GetOtherProfilesResponse>
    {

    }

    public class GetOtherProfilesResponse
    {

    }

    public class GetOtherProfilesQuery : IAsyncRequestHandler<GetOtherProfilesRequest, GetOtherProfilesResponse>
    {
        public Task<GetOtherProfilesResponse> Handle(GetOtherProfilesRequest message)
        {
            throw new NotImplementedException();
        }
    }
}
