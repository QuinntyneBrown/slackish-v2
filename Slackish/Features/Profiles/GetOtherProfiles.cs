using System;
using System.Threading.Tasks;
using MediatR;
using Slackish.Data;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace Slackish.Features.Profiles
{
    public class GetOtherProfilesQuery
    {
        public class GetOtherProfilesRequest : IRequest<GetOtherProfilesResponse>
        {
            public string Username { get; set; }
            public int OtherProfileId { get; set; }
        }

        public class GetOtherProfilesResponse
        {
            public ICollection<ProfileApiModel> Profiles { get; set; } = new HashSet<ProfileApiModel>();
        }

        public class GetOtherProfilesHandler : IAsyncRequestHandler<GetOtherProfilesRequest, GetOtherProfilesResponse>
        {
            public GetOtherProfilesHandler(SlackishDbContext slackishDbContext)
            {
                _slackishDbContext = slackishDbContext;
            }

            public async Task<GetOtherProfilesResponse> Handle(GetOtherProfilesRequest message)
            {
                var response = new GetOtherProfilesResponse();

                var profiles = await _slackishDbContext
                    .Profiles
                    .Where(x => x.User.Username != message.Username)
                    .ToListAsync();

                response.Profiles = profiles
                    .Select(x => ProfileApiModel.FromProfile(x))
                    .ToList();

                return  response;
            }

            protected SlackishDbContext _slackishDbContext { get; set; }
        }

    }

}
