using Slackish.Data.Models;

namespace Slackish.ApiModels
{
    public class MessageApiModel
    {

        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public int ConversationId { get; set; }
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
            return model;
        }

        public static MessageApiModel FromMessage(Message message) => FromMessage<MessageApiModel>(message);
    }
}
