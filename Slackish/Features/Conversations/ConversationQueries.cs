using Slackish.Data;

namespace Slackish.Queries
{
    public interface IConversationQueries
    {

    }

    public class GetByCurrentProfileAsync{
        public GetByCurrentProfileAsync(DataContext dataContext)
        {

        }
    }

    public class ConversationQueries: IConversationQueries
    {
        public ConversationQueries(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private DataContext _dataContext { get; set; }
    }
}
