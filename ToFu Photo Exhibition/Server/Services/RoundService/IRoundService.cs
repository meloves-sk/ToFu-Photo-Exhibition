namespace ToFu_Photo_Exhibition.Server.Services.RoundService
{
	public interface IRoundService
	{
		Task<ServiceResponse<IEnumerable<RoundResponseDto>>> GetFilterRoundsAsync(int categoryId);
		Task<ServiceResponse<bool>> SaveRound(RoundRequestDto roundRequestDto);
		Task<ServiceResponse<bool>> DeleteRound(int roundId);
	}
}
