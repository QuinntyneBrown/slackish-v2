using Slackish.Data.Models;
using System.Collections.Generic;

namespace Slackish.ApiModels
{
    public class ConversationApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromMessage<TModel>(Conversation conversation) where
            TModel : ConversationApiModel, new()
        {
            var model = new TModel();
            model.Id = conversation.Id;
            return model;
        }
    }
}
