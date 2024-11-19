using ToFu_Photo_Exhibition.Shared.Dto.Request;

namespace ToFu_Photo_Exhibition.Server.Services.TeamService
{
	public class TeamService : ITeamService
	{
		private readonly DB _db;
		public TeamService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<IEnumerable<TeamResponseDto>>> GetTeamsAsync(int categoryId, int manufacturerId)
		{
			List<TeamResponseDto> teams = new List<TeamResponseDto>();
			teams.Add(new TeamResponseDto(0, "すべて"));
			Filter(await _db.Teams.Include(a => a.TeamInformations).Where(a => a.TeamInformations.Any(b => b.CategoryId == categoryId)).ToListAsync(), manufacturerId).ToList().ForEach(a =>
			{
				teams.Add(new TeamResponseDto(a.Id, a.Name));
			});
			return new ServiceResponse<IEnumerable<TeamResponseDto>>
			{
				Data = teams,
				Success = true,
				Message = "Success"
			};
		}

		public async Task SaveTeam(TeamRequestDto teamRequestDto)
		{
			Team team = await _db.Teams.FindAsync(teamRequestDto.Id) ?? new Team();
			team.Name = teamRequestDto.Name;
			if (team.Id == 0) _db.Teams.Add(team);
			await _db.SaveChangesAsync();
		}

		private List<Team> Filter(List<Team> teams, int manufacturerId)
		{
			if (manufacturerId != 0) return Filter(teams.Where(a => a.TeamInformations.Any(b => b.ManufacturerId == manufacturerId)).ToList(), 0);
			return teams;
		}
	}
}
