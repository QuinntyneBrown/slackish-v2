using MediatR;
using Slackish.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using Slackish.Utilities;

namespace Slackish.Features.Messages
{
    public class GetMessagesQuery: IRequest<GetMessagesResponse>
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
            _slackishDbContext = dataContext;
        }

        public async Task<GetMessagesResponse> Handle(GetMessagesQuery query)
        {
            var messages = await _slackishDbContext.Messages
                .Include(x=>x.Conversation)
                .Select(x => MessageApiModel.FromMessage(x))
                .ToListAsync();

            return new GetMessagesResponse()
            {
                Messages = messages
            };
        }

        private SlackishDbContext _slackishDbContext;
        private ICache _cache;
    }
}
