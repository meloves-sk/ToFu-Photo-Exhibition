
using static System.Net.WebRequestMethods;

namespace ToFu_Photo_Exhibition.Client.Services.RoundService
{
	public class RoundService : IRoundService
	{
		private readonly HttpClient _http;
		public RoundService(HttpClient http)
		{
			_http = http;
		}

		public List<RoundResponseDto> Rounds { get; } = new List<RoundResponseDto>();

		public async Task GetFilterRounds(int categoryId)
		{
			Rounds.Clear();
			var result = await _http.GetFromJsonAsync<ServiceResponse<IEnumerable<RoundResponseDto>>>($"api/round/category/{categoryId}");
			if (result != null) Rounds.AddRange(result.Data);
		}
	}
}
