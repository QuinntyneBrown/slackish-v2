using Slackish.Data.Models;

namespace Slackish.Features.Conversations
{
    public class ConversationApiModel
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromConversation<TModel>(Conversation conversation) where
            TModel : ConversationApiModel, new()
        {
            var model = new TModel();
            model.Id = conversation.Id;
            return model;
        }

        public static ConversationApiModel FromConversation(Conversation conversation)
            => FromConversation<ConversationApiModel>(conversation);
    }
}
