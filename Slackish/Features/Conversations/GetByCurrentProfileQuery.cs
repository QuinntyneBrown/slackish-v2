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

    public class GetByCurrentProfileQuery: IAsyncRequest<List<Conversation>> {
        public GetByCurrentProfileQuery(string usernmae)
        {
            Username = Username;
        }

        public string Username { get; set; }
    }

    public class GetByCurrentProfileHandler : IAsyncRequestHandler<GetByCurrentProfileQuery, List<Conversation>>
    {

        public GetByCurrentProfileHandler(DataContext dataContext, ICacheProvider cacheProvider)
        {
            _dataContext = dataContext;
            _cache = cacheProvider.GetCache();
        }

        public async Task<List<Conversation>> Handle(GetByCurrentProfileQuery message)
        {
            return await _dataContext.Conversations
                .Include(x => x.Profiles)
                .Include(x => x.Messages)
                .Include("Profiles.User")
                .Where(x => x.Profiles.Any(p => p.User.Username == message.Username))
                .ToListAsync();
        }

        private readonly DataContext _dataContext;
        private readonly ICache _cache;

    }
}
