namespace ToFu_Photo_Exhibition.Server.Services.RoundService
{
	public interface IRoundService
	{
		Task<ServiceResponse<List<Round>>> GetRoundsAsync(int categoryId);
	}
}
