namespace ToFu_Photo_Exhibition.Server.Services.TeamService
{
	public class TeamService : ITeamService
	{
		private readonly DB _db;
		public TeamService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<List<Team>>> GetTeamsAsync(int categoryId, int manufacturerId)
		{
			List<Team> teams = new List<Team>();
			teams.Add(new Team { Id = 0, Name = "すべて" });
			List<Team> getTeams = await _db.Teams.Include(a => a.TeamInformations).ToListAsync();
			teams.AddRange(Filter(getTeams.Where(a => a.TeamInformations.Any(b => b.CategoryId == categoryId)).ToList(), manufacturerId));
			ServiceResponse<List<Team>> response = new ServiceResponse<List<Team>>
			{
				Data = teams,
				Success = true,
				Message = "Success"
			};
			return response;
		}

		private List<Team> Filter(List<Team> teams, int manufacturerId)
		{
			if (manufacturerId != 0) return Filter(teams.Where(a => a.TeamInformations.Any(b => b.ManufacturerId == manufacturerId)).ToList(), 0);
			return teams;
		}
	}
}
