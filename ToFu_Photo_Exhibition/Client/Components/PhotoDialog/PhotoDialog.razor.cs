namespace ToFu_Photo_Exhibition.Client.Components.PhotoDialog
{
	public partial class PhotoDialog
	{
		private bool _show = false;
		private bool _isDebug = false;
		private PhotoResponseDto _photo = null!;
		public void Show(PhotoResponseDto photo)
		{
#if DEBUG
			_isDebug = true;
#endif
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
