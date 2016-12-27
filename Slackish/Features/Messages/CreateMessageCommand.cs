using Slackish.Requests;

namespace Slackish.Commands
{
    public class CreateMessageCommand
    {
        public CreateMessageCommand(CreateMessageRequest request)
        {
            _request = request;
        }

        private CreateMessageRequest _request;
    }
}
