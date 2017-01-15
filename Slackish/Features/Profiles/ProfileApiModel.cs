using Slackish.Data.Models;
using Slackish.Features.Conversations;
using System.Collections.Generic;
using System.Linq;

namespace Slackish.Features.Profiles
{
    public class ProfileApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserApiModel User { get; set; }
        public ICollection<ConversationApiModel> Conversations { get; set; } = new HashSet<ConversationApiModel>();

        public static TModel FromProfile<TModel>(Profile profile) where
            TModel : ProfileApiModel, new()
        {
            var model = new TModel();
            model.Id = profile.Id;
            model.User = UserApiModel.FromUser(profile.User);
            model.Conversations = profile.Conversations.Select(x => ConversationApiModel.FromConversation(x)).ToList();
            return model;
        }

        public static ProfileApiModel FromProfile(Profile profile)
            => FromProfile<ProfileApiModel>(profile);
    }
    
}
