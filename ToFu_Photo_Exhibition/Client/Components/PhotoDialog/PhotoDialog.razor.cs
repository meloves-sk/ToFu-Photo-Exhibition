namespace ToFu_Photo_Exhibition.Client.Components.PhotoDialog
{
	public partial class PhotoDialog
	{
		private bool _show = false;
		private PhotoResponseDto _photo = null!;
		public void Show(PhotoResponseDto photo)
		{
			_photo = photo;
			_show = true;
			StateHasChanged();
		}

		private void CloseButtonOnClick()
		{
			_show = false;
			StateHasChanged();
		}
	}
}
