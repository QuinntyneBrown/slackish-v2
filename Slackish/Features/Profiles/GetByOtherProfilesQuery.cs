using System;
using System.Threading.Tasks;
using MediatR;

namespace Slackish.Features.Profiles
{
    public class GetByOtherProfilesQuery
    {
        public class GetOtherProfilesRequest : 
            IAsyncRequest<GetOtherProfilesResponse>
        {
            public int OtherProfileId { get; set; }
        }

        public class GetOtherProfilesResponse
        {

        }

        public class GetByOtherProfilesHandler : IAsyncRequestHandler<GetOtherProfilesRequest, GetOtherProfilesResponse>
        {
            public Task<GetOtherProfilesResponse> Handle(GetOtherProfilesRequest message)
            {
                throw new NotImplementedException();
            }
        }

    }

}
