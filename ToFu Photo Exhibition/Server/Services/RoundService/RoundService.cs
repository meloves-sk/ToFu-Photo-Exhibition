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
			List<Round> getRounds = await _db.Rounds.ToListAsync();
			rounds.AddRange(getRounds.Where(a => a.CategoryId == categoryId));
			ServiceResponse<List<Round>> response = new ServiceResponse<List<Round>>
			{
				Data = rounds,
				Success = true,
				Message = "Success"
			};
			return response;
		}
	}
}
