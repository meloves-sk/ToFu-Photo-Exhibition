namespace ToFu_Photo_Exhibition.Server.Services.RoundService
{
	public class RoundService : IRoundService
	{
		private readonly DB _db;
		public RoundService(DB db)
		{
			_db = db;
		}
		public async Task<ServiceResponse<List<Round>>> GetRoundsAsync()
		{
			List<Round> rounds = await _db.Rounds.ToListAsync();
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
