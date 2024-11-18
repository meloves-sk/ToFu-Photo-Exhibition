
using System.Runtime.CompilerServices;

namespace ToFu_Photo_Exhibition.Server.Services.TeamInformationService
{
	public class TeamInformationService : ITeamInformationService
	{
		private readonly DB _db;
		public TeamInformationService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<List<TeamInformation>>> GetTeamInformationsAsync()
		{
			List<TeamInformation> teamInformations = await _db.TeamInformations.Include(a => a.Manufacturer).Include(a => a.Team).Include(a => a.Category).ToListAsync();
			ServiceResponse<List<TeamInformation>> response = new ServiceResponse<List<TeamInformation>>
			{
				Data = teamInformations,
				Success = true,
				Message = "Success"
			};
			return response;
		}

		public async Task SaveTeamInformation(TeamInformation teamInformation)
		{
			TeamInformation _teamInformation = await _db.TeamInformations.FindAsync(teamInformation.Id) ?? new TeamInformation();
			_teamInformation.TeamId = teamInformation.Id;
			_teamInformation.ManufacturerId = teamInformation.ManufacturerId;
			_teamInformation.CategoryId = teamInformation.CategoryId;
			if(_teamInformation.Id == 0)_db.TeamInformations.Add(_teamInformation);
			_db.SaveChanges();
		}
	}
}
