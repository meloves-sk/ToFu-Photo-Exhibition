using ToFu_Photo_Exhibition.Shared.Dto.Request;

namespace ToFu_Photo_Exhibition.Server.Services.CarService
{
	public interface ICarService
	{
		Task<ServiceResponse<IEnumerable<CarResponseDto>>> GetCarAsync(int categoryId, int manufacturerId, int teamId);
		Task SaveCar(CarRequestDto carRequestDto);
	}
}
