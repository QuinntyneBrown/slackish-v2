using System;
using System.Threading.Tasks;
using MediatR;

namespace Slackish.Features.Messages
{
    public class SendMessageCommand
    {

        public class SendMessageRequest: IAsyncRequest<SendMessageResponse>
        {

        }

        public class SendMessageResponse
        {

        }

        public class SendMessageHandler
            : IAsyncRequestHandler<SendMessageRequest, SendMessageResponse>
        {
            public Task<SendMessageResponse> Handle(SendMessageRequest message)
            {
                throw new NotImplementedException();
            }
        }
    }
}
