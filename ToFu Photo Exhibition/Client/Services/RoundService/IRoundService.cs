namespace ToFu_Photo_Exhibition.Client.Services.RoundService
{
	public interface IRoundService
	{
		List<RoundResponseDto> Rounds { get; }
		Task GetFilterRounds(int categoryId);
	}
}
