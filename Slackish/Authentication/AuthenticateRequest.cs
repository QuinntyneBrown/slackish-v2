using MediatR;

namespace Slackish.Authentication
{
    public class AuthenticateRequest : IAsyncRequest<AuthenticateResponse>
    {
        public AuthenticateRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
