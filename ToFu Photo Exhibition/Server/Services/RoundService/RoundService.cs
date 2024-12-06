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

		public async Task<ServiceResponse<IEnumerable<RoundResponseDto>>> GetFilterRoundsAsync(int categoryId)
		{
			var filterRounds = Filter(await _db.Rounds.ToListAsync(), categoryId);
			IEnumerable<RoundResponseDto> rounds = filterRounds.Select(a =>
			new RoundResponseDto(
				a.Id,
				a.Name));
			return new ServiceResponse<IEnumerable<RoundResponseDto>>(rounds, true, "正常に取得されました");
		}

		public async Task<ServiceResponse<bool>> SaveRound(RoundRequestDto roundRequestDto)
		{
			if (await _db.Rounds.Where(a => a.Id != roundRequestDto.Id).AnyAsync(a => a.CategoryId == roundRequestDto.CategoryId && a.Name == roundRequestDto.Name))
			{
				return new ServiceResponse<bool>(false, false, "このラウンド情報は既に登録されています");
			}
			Round round = await _db.Rounds.FindAsync(roundRequestDto.Id) ?? new Round();
			round.Name = round.Name;
			round.CategoryId = roundRequestDto.CategoryId;
			if (round.Id == 0)
			{
				_db.Rounds.Add(round);
			}
			await _db.SaveChangesAsync();
			return new ServiceResponse<bool>(true, true, "正常に保存されました");
		}

		private List<Round> Filter(List<Round> rounds, int categoryId)
		{
			if (categoryId != 0)
			{
				return Filter(rounds.Where(a => a.CategoryId == categoryId).ToList(), 0);
			}
			return rounds;
		}
	}
}
