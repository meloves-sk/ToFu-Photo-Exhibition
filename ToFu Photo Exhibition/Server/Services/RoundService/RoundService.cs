namespace ToFu_Photo_Exhibition.Server.Services.RoundService
{
	public class RoundService : IRoundService
	{
		private readonly DB _db;
		public RoundService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<List<Round>>> GetRoundsAsync(int categoryId)
		{
			List<Round> rounds = new List<Round>();
			rounds.Add(new Round { Id = 0, Name = "すべて" });
			rounds.AddRange(await _db.Rounds.Where(a => a.CategoryId == categoryId).ToListAsync());
			ServiceResponse<List<Round>> response = new ServiceResponse<List<Round>>
			{
				Data = rounds,
				Success = true,
				Message = "Success"
			};
			return response;
		}

		public async Task SaveRound(Round round)
		{
			Round _round = await _db.Rounds.FindAsync(round.Id) ?? new Round();
			_round.Name = _round.Name;
			_round.CategoryId = round.CategoryId;
			if (_round.Id == 0) _db.Rounds.Add(_round);
			_db.SaveChanges();
		}
	}
}
