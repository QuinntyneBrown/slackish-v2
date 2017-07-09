using System;
using System.Threading.Tasks;
using MediatR;
using Slackish.Data;
using System.Linq;
using Slackish.Data.Models;

namespace Slackish.Features.Messages
{
    public class SendMessageCommand
    {

        public class SendMessageRequest: IAsyncRequest<SendMessageResponse>
        {
            public string Content { get; set; }
            public int OtherProfileId { get; set; }
            public string Username { get; set; }
        }

        public class SendMessageResponse
        {

        }

        public class SendMessageHandler
            : IAsyncRequestHandler<SendMessageRequest, SendMessageResponse>
        {
            public SendMessageHandler(SlackishDbContext slackishDbContext)
            {
                _context = slackishDbContext;
            }

            public Task<SendMessageResponse> Handle(SendMessageRequest message)
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

                return Task.FromResult(new SendMessageResponse());
            }

            protected SlackishDbContext _context { get; set; }
        }
    }
}
