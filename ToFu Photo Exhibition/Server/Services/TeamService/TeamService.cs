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

		public async Task<ServiceResponse<IEnumerable<TeamResponseDto>>> GetFilterTeamsAsync(int categoryId, int manufacturerId)
		{
			IEnumerable<TeamResponseDto> teams = Filter(await _db.Teams.Include(a => a.TeamInformations).Where(a => a.TeamInformations.Any(b => b.CategoryId == categoryId)).ToListAsync(), manufacturerId)
				.Select(a => new TeamResponseDto(a.Id, a.Name));
			return new ServiceResponse<IEnumerable<TeamResponseDto>>(teams, true, "正常に取得されました");
		}

		public async Task<ServiceResponse<bool>> SaveTeam(TeamRequestDto teamRequestDto)
		{
			if (await _db.Teams.Where(a => a.Id != teamRequestDto.Id).AnyAsync(a => a.Name == teamRequestDto.Name))
			{
				return new ServiceResponse<bool>(false, false, "このチーム情報は既に登録されています");
			}
			Team team = await _db.Teams.FindAsync(teamRequestDto.Id) ?? new Team();
			team.Name = teamRequestDto.Name;
			if (team.Id == 0)
			{
				_db.Teams.Add(team);
			}
			await _db.SaveChangesAsync();
			return new ServiceResponse<bool>(true, true, "正常に保存されました");
		}

		private List<Team> Filter(List<Team> teams, int manufacturerId)
		{
			if (manufacturerId != 0)
			{
				return Filter(teams.Where(a => a.TeamInformations.Any(b => b.ManufacturerId == manufacturerId)).ToList(), 0);
			}
			return teams;
		}
	}
}
