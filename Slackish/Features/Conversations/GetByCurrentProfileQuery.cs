using MediatR;
using Slackish.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Slackish.Features.Core;

namespace Slackish.Features.Conversations
{
    public class GetByCurrentProfileQuery
    {
        public class GetByCurrentProfileRequest : IRequest<GetByCurrentProfileResponse>
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
                _context = dataContext;
                _cache = cache;
            }

            public async Task<GetByCurrentProfileResponse> Handle(GetByCurrentProfileRequest request)
            {
                var results = await _cache.FromCacheOrServiceAsync(() => _context.Conversations
                    .Include(x => x.Profiles)
                    .Include(x => x.Messages)
                    .Include("Profiles.User")
                    .Where(x => x.Profiles.Any(p => p.User.Username == request.Username)  && x.IsDeleted == false)                    
                    .ToListAsync(),$"[Conversation] GetByCurrentProfile: {request.Username}");

                return new GetByCurrentProfileResponse(results
                    .Select(x => ConversationApiModel.FromConversation(x))
                    .ToList());
            }

            private readonly SlackishDbContext _context;
            private readonly ICache _cache;
        }
    }
}
