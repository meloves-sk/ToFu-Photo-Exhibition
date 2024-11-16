namespace ToFu_Photo_Exhibition.Server.Services.TeamService
{
	public class TeamService : ITeamService
	{
		private readonly DB _db;
		public TeamService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<List<Team>>> GetTeamsAsync()
		{
			List<Team> teams = await _db.Teams.ToListAsync();
			ServiceResponse<List<Team>> response = new ServiceResponse<List<Team>>
			{
				Data = teams,
				Success = true,
				Message = "Success"
			};
			return response;
		}
	}
}
