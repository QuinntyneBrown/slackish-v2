using MediatR;
using Microsoft.AspNet.SignalR;
using System;

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

        public class Handler : IRequestHandler<Request>
        {
            public Handler(IMediator mediator)
            {
                _meditator = mediator;
            }
 
            public void Handle(Request request)
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();

                context.Clients.Group($"{request.TenantUniqueId}").messages(request);

                try
                {
                    _meditator.Send(new SendMessageCommand.Request() {
                        Content = request.Content,
                        OtherProfileId = request.OtherProfileId,
                        Username = request.Username,
                        TenantUniqueId = request.TenantUniqueId
                    });
                }
                catch
                {
                    context.Clients.Group($"{request.TenantUniqueId}").failedMessages(request);                    
                }             
            }

            private readonly IMediator _meditator;
        }
    }
}
