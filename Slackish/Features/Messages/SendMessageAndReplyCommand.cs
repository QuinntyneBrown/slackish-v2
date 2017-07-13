using MediatR;
using Microsoft.AspNet.SignalR;
using System;

using static Slackish.Features.Messages.SendMessageCommand;

namespace Slackish.Features.Messages
{
    public class SendMessageAndReplyCommand
    {
        public class Request : MediatR.IRequest
        {
            public Guid CorrelationId { get; set; }
            public string Content { get; set; }
            public int OtherProfileId { get; set; }
            public string Username { get; set; }
            public Guid TenantUniqueId { get; set; }
        }

        public class SendMessageAndReplyHandler : IRequestHandler<Request>
        {
            public SendMessageAndReplyHandler(IMediator mediator)
            {
                _meditator = mediator;
            }
 
            public void Handle(Request request)
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();

                try
                {
                    _meditator.Send(new SendMessageRequest() {
                        Content = request.Content,
                        OtherProfileId = request.OtherProfileId,
                        Username = request.Username,
                        TenantUniqueId = request.TenantUniqueId
                    });
                }
                catch
                {
                    context.Clients.All.failedMessages(request);                    
                }

                context.Clients.All.messages(request);                
            }

            private readonly IMediator _meditator;
        }
    }
}
