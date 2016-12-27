using MediatR;
using Slackish.ApiModels;
using Slackish.Data;
using Slackish.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using Slackish.Services;

namespace Slackish.Queries
{
    public class MessagesQuery: IAsyncRequest<List<MessageApiModel>>
    {
        public MessagesQuery() { }        
    }

    public class MessagesQueryHandler: IAsyncRequestHandler<MessagesQuery, List<MessageApiModel>>
    {
        public MessagesQueryHandler(DataContext dataContext, ICacheProvider cacheProvider)
        {
            _cache = cacheProvider.GetCache();
            _dataContext = dataContext;
        }

        public async Task<List<MessageApiModel>> Handle(MessagesQuery query)
        {
            return await _dataContext.Messages
                .Select(x => MessageApiModel.FromMessage<MessageApiModel>(x))
                .ToListAsync();
        }

        private DataContext _dataContext;
        private ICache _cache;
    }
}
