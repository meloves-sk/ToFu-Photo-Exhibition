namespace ToFu_Photo_Exhibition.Shared.Dto.Response
{
	public class ServiceResponse<T>
	{
		public ServiceResponse(T data, bool success, string message)
		{
			Data = data;
			Success = success;
			Message = message;
		}
		public T Data { get; }
		public bool Success { get; }
		public string Message { get; }
	}
}
