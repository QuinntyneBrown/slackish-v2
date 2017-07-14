using Slackish.Data.Model;

namespace Slackish.Features.Teams
{
    public class TeamApiModel
    {        
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Name { get; set; }

        public static TModel FromTeam<TModel>(Team team) where
            TModel : TeamApiModel, new()
        {
            var model = new TModel();
            model.Id = team.Id;
            model.TenantId = team.TenantId;
            model.Name = team.Name;
            return model;
        }

        public static TeamApiModel FromTeam(Team team)
            => FromTeam<TeamApiModel>(team);

    }
}
