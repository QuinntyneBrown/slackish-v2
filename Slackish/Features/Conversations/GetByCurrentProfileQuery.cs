using MediatR;
using Slackish.Data;
using Slackish.Data.Models;
using Slackish.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Slackish.Features.Conversations
{

    public class GetByCurrentProfileRequest: IAsyncRequest<List<Conversation>> {
        public GetByCurrentProfileRequest(string usernmae)
        {
            Username = Username;
        }

        public string Username { get; set; }
    }

    public class GetByCurrentProfileQuery : IAsyncRequestHandler<GetByCurrentProfileRequest, List<Conversation>>
    {

        public GetByCurrentProfileQuery(DataContext dataContext, ICache cache)
        {
            _dataContext = dataContext;
            _cache = cache;
        }

        public async Task<List<Conversation>> Handle(GetByCurrentProfileRequest request)
        {
            return await _dataContext.Conversations
                .Include(x => x.Profiles)
                .Include(x => x.Messages)
                .Include("Profiles.User")
                .Where(x => x.Profiles.Any(p => p.User.Username == request.Username))
                .ToListAsync();
        }

        private readonly DataContext _dataContext;
        private readonly ICache _cache;

    }
}
