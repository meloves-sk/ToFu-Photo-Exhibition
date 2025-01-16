namespace ToFu_Photo_Exhibition.Client.Shared.NavMenu
{
	public partial class NavMenu
	{
		private bool collapseNavMenu = true;
		private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;
		protected override async Task OnInitializedAsync()
		{
			await CategoryService.GetCategories();
		}
		private void ToggleNavMenu()
		{
			collapseNavMenu = !collapseNavMenu;
		}
	}
}
