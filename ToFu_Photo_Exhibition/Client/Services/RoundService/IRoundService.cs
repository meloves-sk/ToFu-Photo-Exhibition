namespace ToFu_Photo_Exhibition.Client.Services.RoundService
{
	public interface IRoundService
	{
		List<RoundResponseDto> Rounds { get; }
		bool IsInitializeOrSearch { get; set; }
		Task GetFilterRounds(int categoryId);
	}
}
