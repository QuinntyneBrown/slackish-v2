using MediatR;
using Slackish.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using Slackish.Utilities;

namespace Slackish.Features.Messages
{
    public class GetMessagesQuery: IAsyncRequest<GetMessagesResponse>
    {
        public GetMessagesQuery() { }        
    }

    public class GetMessagesResponse 
    {
        public List<MessageApiModel> Messages { get; set; }
    }

    public class GetMessagesQueryHandler: IAsyncRequestHandler<GetMessagesQuery, GetMessagesResponse>
    {
        public GetMessagesQueryHandler(SlackishDbContext dataContext, ICache cache)
        {
            _cache = cache;
            _context = dataContext;
        }

        public async Task<GetMessagesResponse> Handle(GetMessagesQuery query)
        {
            var messages = await _context.Messages
                .Include(x=>x.Conversation)
                .Select(x => MessageApiModel.FromMessage(x))
                .ToListAsync();

            return new GetMessagesResponse()
            {
                Messages = messages
            };
        }

        private SlackishDbContext _context;
        private ICache _cache;
    }
}
