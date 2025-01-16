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
		public bool IsInitializeOrSearch { get; set; } = true;

		public async Task GetFilterRounds(int categoryId)
		{
			Rounds.Clear();
			IsInitializeOrSearch = true;
			var result = await _http.GetFromJsonAsync<ServiceResponse<IEnumerable<RoundResponseDto>>>($"api/round/category/{categoryId}");
			if (result != null && result.Data != null)
			{
				Rounds.Add(new RoundResponseDto(0, "ALL"));
				Rounds.AddRange(result.Data);
				IsInitializeOrSearch = false;
			}
		}
	}
}
