using System;
using System.Threading.Tasks;
using MediatR;

namespace Slackish.Features.Profiles
{
    public class RegisterRequest: IAsyncRequest<RegisterResponse>
    {

    }

    public class RegisterResponse
    {

    }

    public class RegisterCommand: IAsyncRequestHandler<RegisterRequest,RegisterResponse>
    {
        public Task<RegisterResponse> Handle(RegisterRequest message)
        {
            throw new NotImplementedException();
        }
    }
}
