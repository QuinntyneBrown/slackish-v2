using MediatR;
using Slackish.Data;
using Slackish.Features.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Slackish.Features.Messages
{
    public class GetMessagesRequest: IRequest<GetMessagesResponse>
    {
        public GetMessagesRequest() { }
        public Guid TenantUniqueId { get; set; }
    }

    public class GetMessagesResponse 
    {
        public List<MessageApiModel> Messages { get; set; }
    }

    public class GetMessagesHandler: IAsyncRequestHandler<GetMessagesRequest, GetMessagesResponse>
    {
        public GetMessagesHandler(SlackishContext dataContext, ICache cache)
        {
            _cache = cache;
            _context = dataContext;
        }

        public async Task<GetMessagesResponse> Handle(GetMessagesRequest query)
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

        private SlackishContext _context;
        private ICache _cache;
    }
}
