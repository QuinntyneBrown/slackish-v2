using MediatR;
using Slackish.Data;
using Slackish.Features.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Slackish.Features.Conversations
{
    public class GetByCurrentProfileQuery
    {
        public class Request : IRequest<Response>
        {
            public Request(string usernmae)
            {
                Username = Username;
            }
            public Guid TenantUniqueId { get; set; }
            public string Username { get; set; }
        }

        public class Response
        {
            public Response(ICollection<ConversationApiModel> conversations)
            {
                Conversations = conversations;
            }

            public ICollection<ConversationApiModel> Conversations { get; set; }
        }

        public class Handler : IAsyncRequestHandler<Request, Response>
        {

            public Handler(SlackishContext dataContext, ICache cache)
            {
                _context = dataContext;
                _cache = cache;
            }

            public async Task<Response> Handle(Request request)
            {
                var results = await _cache.FromCacheOrServiceAsync(() => _context.Conversations
                    .Include(x => x.Profiles)
                    .Include(x => x.Messages)
                    .Include("Profiles.User")
                    .Where(x => x.Profiles.Any(p => p.User.Username == request.Username))                    
                    .ToListAsync(),$"[Conversation] GetByCurrentProfile: {request.Username}");

                return new Response(results
                    .Select(x => ConversationApiModel.FromConversation(x))
                    .ToList());
            }

            private readonly SlackishContext _context;
            private readonly ICache _cache;
        }
    }
}
