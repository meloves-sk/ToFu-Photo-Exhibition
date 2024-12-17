namespace ToFu_Photo_Exhibition.Client.Services.RoundService
{
	public interface IRoundService
	{
		List<RoundResponseDto> Rounds { get; }
		bool IsSearch { get; set; }
		Task GetFilterRounds(int categoryId);
	}
}
