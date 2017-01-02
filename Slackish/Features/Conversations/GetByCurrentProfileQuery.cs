using MediatR;
using Slackish.Data;
using Slackish.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Slackish.Features.Conversations
{
    public class GetByCurrentProfileQuery
    {
        public class GetByCurrentProfileRequest : IAsyncRequest<GetByCurrentProfileResponse>
        {
            public GetByCurrentProfileRequest(string usernmae)
            {
                Username = Username;
            }

            public string Username { get; set; }
        }

        public class GetByCurrentProfileResponse
        {
            public GetByCurrentProfileResponse(ICollection<ConversationApiModel> conversations)
            {
                Conversations = conversations;
            }

            public ICollection<ConversationApiModel> Conversations { get; set; }
        }

        public class GetByCurrentProfileHandler : IAsyncRequestHandler<GetByCurrentProfileRequest, GetByCurrentProfileResponse>
        {

            public GetByCurrentProfileHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetByCurrentProfileResponse> Handle(GetByCurrentProfileRequest request)
            {
                var results = await _dataContext.Conversations
                    .Include(x => x.Profiles)
                    .Include(x => x.Messages)
                    .Include("Profiles.User")
                    .Where(x => x.Profiles.Any(p => p.User.Username == request.Username))
                    .ToListAsync();

                return new GetByCurrentProfileResponse(results
                    .Select(x => ConversationApiModel.FromConversation(x))
                    .ToList());
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
