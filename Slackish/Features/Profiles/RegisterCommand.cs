using Slackish.Features.Profiles;
using Slackish.Requests;

namespace Slackish.Commands
{
    public class RegisterCommand
    {
        public RegisterCommand(RegistrationRequest registrationRequest)
        {
            _registrationRequest = registrationRequest;
        }

        private RegistrationRequest _registrationRequest { get; set; }
    }
}
