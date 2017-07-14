using Slackish.Data.Model;
using Slackish.Features.Messages;
using Slackish.Features.Profiles;
using System.Collections.Generic;
using System.Linq;

namespace Slackish.Features.Conversations
{
    public class ConversationApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public ICollection<ProfileApiModel> Profiles { get; set; } = new HashSet<ProfileApiModel>();
        public ICollection<MessageApiModel> Messages { get; set; } = new HashSet<MessageApiModel>();

        public static TModel FromConversation<TModel>(Conversation conversation) where
            TModel : ConversationApiModel, new()
        {
            var model = new TModel();
            model.Id = conversation.Id;
            model.TenantId = conversation.TenantId;
            model.Profiles = conversation.Profiles.Select(x => ProfileApiModel.FromProfile(x)).ToList();
            model.Messages = conversation.Messages.Select(x => MessageApiModel.FromMessage(x)).ToList();
            return model;
        }

        public static ConversationApiModel FromConversation(Conversation conversation)
            => FromConversation<ConversationApiModel>(conversation);
    }
}
