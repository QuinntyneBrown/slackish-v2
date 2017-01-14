using MediatR;
using Slackish.Data;
using Slackish.Utilities;
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

            public GetByCurrentProfileHandler(SlackishDbContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<GetByCurrentProfileResponse> Handle(GetByCurrentProfileRequest request)
            {
                var results = await _cache.FromCacheOrServiceAsync(() => _dataContext.Conversations
                    .Include(x => x.Profiles)
                    .Include(x => x.Messages)
                    .Include("Profiles.User")
                    .Where(x => x.Profiles.Any(p => p.User.Username == request.Username)  && x.IsDeleted == false)                    
                    .ToListAsync(),"[Conversation] GetByCurrentProfile");

                return new GetByCurrentProfileResponse(results
                    .Select(x => ConversationApiModel.FromConversation(x))
                    .ToList());
            }

            private readonly SlackishDbContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
