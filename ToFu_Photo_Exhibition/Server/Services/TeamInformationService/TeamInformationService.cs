namespace ToFu_Photo_Exhibition.Server.Services.TeamInformationService
{
	public class TeamInformationService : ITeamInformationService
	{
		private readonly DB _db;
		public TeamInformationService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<IEnumerable<TeamInformationResponseDto>>> GetTeamInformationsAsync(int teamId, int manufacturerId, int categoryId)
		{
			var filterTeamInformations = Filter(await _db.TeamInformations.Include(a => a.Team)
				.Include(a => a.Manufacturer).Include(a => a.Category).ToListAsync(),
				teamId, manufacturerId, categoryId);
			IEnumerable<TeamInformationResponseDto> teamInformations = filterTeamInformations.OrderBy(a => a.Team.Name).Select(a =>
			new TeamInformationResponseDto(
				a.Id,
				a.TeamId,
				a.ManufacturerId,
				a.CategoryId,
				a.Team.Name,
				a.Manufacturer.Name,
				a.Category.Name));
			return new ServiceResponse<IEnumerable<TeamInformationResponseDto>>(teamInformations, true, "正常に取得されました");
		}

		public async Task<ServiceResponse<bool>> SaveTeamInformation(TeamInformationRequestDto teamInformationRequestDto)
		{
			if (await _db.TeamInformations.Where(a => a.Id != teamInformationRequestDto.Id).AnyAsync(a => a.CategoryId == teamInformationRequestDto.CategoryId && a.ManufacturerId == teamInformationRequestDto.ManufacturerId && a.TeamId == teamInformationRequestDto.TeamId))
			{
				return new ServiceResponse<bool>(false, false, "このチーム情報は既に登録されています");
			}
			var teamInformation = await _db.TeamInformations.FindAsync(teamInformationRequestDto.Id) ?? new TeamInformation();
			teamInformation.TeamId = teamInformationRequestDto.TeamId;
			teamInformation.ManufacturerId = teamInformationRequestDto.ManufacturerId;
			teamInformation.CategoryId = teamInformationRequestDto.CategoryId;
			if (teamInformation.Id == 0)
			{
				_db.TeamInformations.Add(teamInformation);
			}
			await _db.SaveChangesAsync();
			return new ServiceResponse<bool>(true, true, "正常に保存されました");
		}

		public async Task<ServiceResponse<bool>> DeleteTeamInformation(int teamInformationId)
		{
			var teamInformation = await _db.TeamInformations.Include(a => a.Cars).SingleAsync(a => a.Id == teamInformationId);
			if (teamInformation.Cars.Any())
			{
				return new ServiceResponse<bool>(false, false, "このチーム情報は使用されています");
			}
			_db.TeamInformations.Remove(teamInformation);
			await _db.SaveChangesAsync();
			return new ServiceResponse<bool>(true, true, "正常に削除されました");
		}

		private IEnumerable<TeamInformation> Filter(IEnumerable<TeamInformation> teamInformations, int teamId, int manufacturerId, int categoryId)
		{
			if (teamId != 0)
			{
				return Filter(teamInformations.Where(a => a.TeamId == teamId), 0, manufacturerId, categoryId);
			}
			if (manufacturerId != 0)
			{
				return Filter(teamInformations.Where(a => a.ManufacturerId == manufacturerId), teamId, 0, categoryId);
			}
			if (categoryId != 0)
			{
				return Filter(teamInformations.Where(a => a.CategoryId == categoryId), teamId, manufacturerId, 0);
			}
			return teamInformations;
		}
	}
}
