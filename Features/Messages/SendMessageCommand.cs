using MediatR;
using Slackish.Data;
using Slackish.Data.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Slackish.Features.Messages
{
    public class SendMessageCommand
    {
        public class Request : IRequest<Response>
        {
            public string Content { get; set; }
            public int OtherProfileId { get; set; }
            public string Username { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class Response { }

        public class SendMessageHandler
            : IAsyncRequestHandler<Request, Response>
        {
            public SendMessageHandler(SlackishContext context)
            {
                _context = context;
            }

            public async Task<Response> Handle(Request message)
            {                
                var currentProfile = _context.Profiles
                    .Where(x => x.User.Username == message.Username)
                    .Single();

                var conversation = _context.Conversations
                    .Where(x => x.Profiles.Any(p => p.Id == currentProfile.Id))
                    .Where(x => x.Profiles.Any(p => p.Id == message.OtherProfileId))
                    .FirstOrDefault();

                if (conversation == null)
                {
                    conversation = new Conversation();
                    conversation.Profiles.Add(currentProfile);
                    conversation.Profiles.Add(_context.Profiles.Find(message.OtherProfileId));
                    _context.Conversations.Add(conversation);
                }

                var model = new Message();
                model.FromId = currentProfile.Id;
                model.ToId = message.OtherProfileId;
                model.Body = message.Content;
                conversation.Messages.Add(model);

                _context.SaveChanges();

                return new Response() { };
            }

            protected SlackishContext _context { get; set; }
        }
    }
}
