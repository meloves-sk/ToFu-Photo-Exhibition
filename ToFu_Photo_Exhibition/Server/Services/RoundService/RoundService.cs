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
			IEnumerable<RoundResponseDto> rounds = filterRounds.OrderBy(a => a.Name).Select(a =>
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
			var round = await _db.Rounds.FindAsync(roundRequestDto.Id) ?? new Round();
			round.Name = roundRequestDto.Name;
			round.CategoryId = roundRequestDto.CategoryId;
			if (round.Id == 0)
			{
				_db.Rounds.Add(round);
			}
			await _db.SaveChangesAsync();
			return new ServiceResponse<bool>(true, true, "正常に保存されました");
		}

		public async Task<ServiceResponse<bool>> DeleteRound(int roundId)
		{
			var round = await _db.Rounds.Include(a => a.Photos).SingleAsync(a => a.Id == roundId);
			if (round.Photos.Any())
			{
				return new ServiceResponse<bool>(false, false, "このラウンドは使用されています");
			}
			_db.Rounds.Remove(round);
			await _db.SaveChangesAsync();
			return new ServiceResponse<bool>(true, true, "正常に削除されました");
		}
		private IEnumerable<Round> Filter(IEnumerable<Round> rounds, int categoryId)
		{
			if (categoryId != 0)
			{
				return Filter(rounds.Where(a => a.CategoryId == categoryId), 0);
			}
			return rounds;
		}
	}
}
