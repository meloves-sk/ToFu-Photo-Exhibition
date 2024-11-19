
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;
using System.Runtime.CompilerServices;
using ToFu_Photo_Exhibition.Shared.Dto.Request;

namespace ToFu_Photo_Exhibition.Server.Services.TeamInformationService
{
	public class TeamInformationService : ITeamInformationService
	{
		private readonly DB _db;
		public TeamInformationService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<IEnumerable<TeamInformationResponseDto>>> GetTeamInformationsAsync()
		{
			List<TeamInformationResponseDto> teamInformations = new List<TeamInformationResponseDto>();
			await _db.TeamInformations.Include(a => a.Manufacturer).Include(a => a.Team).Include(a => a.Category).ForEachAsync(a => teamInformations.Add(new TeamInformationResponseDto(a.Id, a.TeamId, a.ManufacturerId, a.CategoryId, a.Team.Name, a.Manufacturer.Name, a.Category.Name)));
			return new ServiceResponse<IEnumerable<TeamInformationResponseDto>>
			{
				Data = teamInformations,
				Success = true,
				Message = "Success"
			};
		}

		public async Task SaveTeamInformation(TeamInformationRequestDto teamInformationRequestDto)
		{
			TeamInformation teamInformation = await _db.TeamInformations.FindAsync(teamInformationRequestDto.Id) ?? new TeamInformation();
			teamInformation.TeamId = teamInformationRequestDto.Id;
			teamInformation.ManufacturerId = teamInformationRequestDto.ManufacturerId;
			teamInformation.CategoryId = teamInformationRequestDto.CategoryId;
			if (teamInformation.Id == 0) _db.TeamInformations.Add(teamInformation);
			await _db.SaveChangesAsync();
		}
	}
}
