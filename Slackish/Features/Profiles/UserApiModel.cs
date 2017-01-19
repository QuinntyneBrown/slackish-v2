using Slackish.Data.Models;

namespace Slackish.Features.Profiles
{
    public class UserApiModel
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
        public static TModel FromUser<TModel>(User user) where
            TModel : UserApiModel, new()
        {
            var model = new TModel();
            model.Id = user.Id;
            model.TenantId = user.TenantId;
            model.Name = user.Name;
            model.Email = user.Email;
            model.Username = user.Username;
            model.Firstname = user.Firstname;
            model.Lastname = user.Lastname;            
            return model;
        }

        public static UserApiModel FromUser(User user)
            => FromUser<UserApiModel>(user);
    }
}
