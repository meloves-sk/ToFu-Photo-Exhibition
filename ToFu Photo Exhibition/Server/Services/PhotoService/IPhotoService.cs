﻿namespace ToFu_Photo_Exhibition.Server.Services.PhotoService
{
    public interface IPhotoService
	{
		Task<ServiceResponse<IEnumerable<PhotoResponseDto>>> GetPhotosAsync(int categoryId, int roundId, int manufacturerId, int teamId, int carId);
	}
}
