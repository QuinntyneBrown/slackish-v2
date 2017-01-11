using Slackish.Data.Models;
using System.Collections.Generic;

namespace Slackish.Features.Profiles
{
    public class ProfileApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static TModel FromProfile<TModel>(Profile profile) where
            TModel : ProfileApiModel, new()
        {
            var model = new TModel();
            model.Id = profile.Id;
            return model;
        }

        public static ProfileApiModel FromProfile(Profile profile)
            => FromProfile<ProfileApiModel>(profile);
    }
}
