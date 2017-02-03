using MediatR;

namespace Slackish.Authentication
{
    public class GetClaimsForUserRequest: IRequest<GetClaimsForUserResponse>
    {
        public GetClaimsForUserRequest(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}
