using Slackish.Data.Models;

namespace Slackish.Features.Profiles
{
    public class UserApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromUser<TModel>(User user) where
            TModel : UserApiModel, new()
        {
            var model = new TModel();
            model.Id = user.Id;
            return model;
        }

        public static UserApiModel FromUser(User user)
            => FromUser<UserApiModel>(user);
    }
}
