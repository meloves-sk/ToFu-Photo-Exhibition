using ToFu_Photo_Exhibition.Shared.Dto.Request;

namespace ToFu_Photo_Exhibition.Server.Services.RoundService
{
	public interface IRoundService
	{
		Task<ServiceResponse<IEnumerable<RoundResponseDto>>> GetRoundsAsync(int categoryId);
		Task SaveRound(RoundRequestDto roundRequestDto);
	}
}
