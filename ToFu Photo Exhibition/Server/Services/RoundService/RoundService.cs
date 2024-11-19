using ToFu_Photo_Exhibition.Shared.Dto.Request;

namespace ToFu_Photo_Exhibition.Server.Services.RoundService
{
	public class RoundService : IRoundService
	{
		private readonly DB _db;
		public RoundService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<IEnumerable<RoundResponseDto>>> GetRoundsAsync(int categoryId)
		{
			List<RoundResponseDto> rounds = new List<RoundResponseDto>();
			rounds.Add(new RoundResponseDto(0, "すべて"));
			await _db.Rounds.Where(a => a.CategoryId == categoryId).ForEachAsync(a => rounds.Add(new RoundResponseDto(a.Id, a.Name)));
			return new ServiceResponse<IEnumerable<RoundResponseDto>>
			{
				Data = rounds,
				Success = true,
				Message = "Success"
			};
		}

		public async Task SaveRound(RoundRequestDto roundRequestDto)
		{
			Round round = await _db.Rounds.FindAsync(roundRequestDto.Id) ?? new Round();
			round.Name = round.Name;
			round.CategoryId = roundRequestDto.CategoryId;
			if (round.Id == 0) _db.Rounds.Add(round);
			await _db.SaveChangesAsync();
		}
	}
}
