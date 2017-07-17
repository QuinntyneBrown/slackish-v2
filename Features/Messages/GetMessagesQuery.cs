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
    public class GetMessagesQuery {
        public class Request: IRequest<Response>
        {
            public Guid TenantUniqueId { get; set; }
            public string Username { get; set; }
        }

        public class Response 
        {
            public List<MessageApiModel> Messages { get; set; }
        }

        public class Handler: IAsyncRequestHandler<Request, Response>
        {
            public Handler(SlackishContext dataContext, ICache cache)
            {
                _cache = cache;
                _context = dataContext;
            }

            public async Task<Response> Handle(Request request)
                => new Response()
                {
                    Messages = await _cache.FromCacheOrServiceAsync(() => _context.Messages
                    .Include(x => x.Conversation)
                    .Select(x => MessageApiModel.FromMessage(x))
                    .ToListAsync(), $"[Messages] Get {request.TenantUniqueId}-{request.Username}")
                };
            
            private SlackishContext _context;
            private ICache _cache;
        }
    }
}