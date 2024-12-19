using Microsoft.VisualBasic;

namespace ToFu_Photo_Exhibition.Client.Pages
{
	public partial class Category
	{
		[Parameter]
		public int Id { get; set; }
		[Parameter]
		public string Name { get; set; } = string.Empty;
		private int roundId;
		private int manufacturerId;
		private int teamId;
		private int carId;
		protected override async Task OnParametersSetAsync()
		{
			await Task.WhenAll(SetRounds(), SetManufacturers());
			await SetTeams();
			await SetCars();
			await SetPhotos();
		}

		private async Task RoundChanged()
		{
			await SetPhotos();
		}

		private async Task ManufacturerChanged()
		{
			teamId = 0;
			carId = 0;
			await SetTeams();
			await SetCars();
			await SetPhotos();
		}

		private async Task TeamChanged()
		{
			carId = 0;
			await SetCars();
			await SetPhotos();
		}

		private async Task CarChanged()
		{
			await SetPhotos();
		}

		private async Task SetRounds()
		{
			await RoundService.GetFilterRounds(Id);
		}
		private async Task SetManufacturers()
		{
			await ManufacturerService.GetFilterManufacturers(Id);
		}
		private async Task SetTeams()
		{
			await TeamService.GetFilterTeams(Id, manufacturerId);
		}
		private async Task SetCars()
		{
			await CarService.GetFilterCars(Id,manufacturerId,teamId);
		}
		private async Task SetPhotos()
		{
			await PhotoService.GetFilterPhotos(Id, roundId, manufacturerId, teamId, carId);
		}
	}
}
