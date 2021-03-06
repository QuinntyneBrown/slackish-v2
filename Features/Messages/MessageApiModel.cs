using Slackish.Data.Model;
using Slackish.Features.Conversations;

namespace Slackish.Features.Messages
{
    public class MessageApiModel
    {
        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public int ConversationId { get; set; }
        public ConversationApiModel Conversation { get; set; }
        public string Body { get; set; }

        public static TModel FromMessage<TModel>(Message message) where
            TModel : MessageApiModel, new()
        {
            var model = new TModel();
            model.Id = message.Id;
            model.FromId = message.FromId;
            model.ToId = message.ToId;
            model.Body = message.Body;
            model.ConversationId = message.ConversationId;
            model.Conversation = ConversationApiModel.FromConversation(message.Conversation);
            return model;
        }

        public static MessageApiModel FromMessage(Message message) 
            => FromMessage<MessageApiModel>(message);
    }
}
