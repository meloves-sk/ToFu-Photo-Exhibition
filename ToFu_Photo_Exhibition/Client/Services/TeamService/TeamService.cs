namespace ToFu_Photo_Exhibition.Client.Services.TeamService
{
	public class TeamService : ITeamService
	{
		private readonly HttpClient _http;
		public TeamService(HttpClient http)
		{
			_http = http;
		}
		public bool IsInitializeOrSearch { get; set; } = true;
		public List<TeamResponseDto> Teams { get; } = new List<TeamResponseDto>();

		public async Task GetFilterTeams(int categoryId, int manufacturerId)
		{
			Teams.Clear();
			IsInitializeOrSearch = true;
			var result = await _http.GetFromJsonAsync<ServiceResponse<IEnumerable<TeamResponseDto>>>($"api/team/category/{categoryId}/manufacturer/{manufacturerId}");
			if (result != null && result.Data != null)
			{
				Teams.Add(new TeamResponseDto(0, "ALL"));
				Teams.AddRange(result.Data);
				IsInitializeOrSearch = false;
			}
		}
	}
}
