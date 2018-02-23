using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmLight.Services
{
	/// <summary>
	/// Extends <see cref="GalaSoft.MvvmLight.Views.IDialogService"/>
	/// </summary>
	public interface IDialogService : GalaSoft.MvvmLight.Views.IDialogService
	{
		Task ShowError(string message, string title, string cancelText, string retryText, Action<bool> afterHideCallback);
		Task ShowError(Exception error, string title, string cancelText, string retryText, Action<bool> afterHideCallback);
		Task ShowActionSheet(string title, string cancel, string destruction, string[] buttons, Action<string> afterHideCallback);
		Task ShowActionSheet(string title, string cancel, string[] buttons, Action<string> afterHideCallback);
	}

	public class DialogService : IDialogService
	{
		private Page _dialogPage;

		public void Initialize(Page dialogPage)
		{
			_dialogPage = dialogPage;
		}

        public async Task ShowActionSheet(string title, string cancel, string destruction, string[] buttons, Action<string> afterHideCallback)
        {
            var result = await _dialogPage.DisplayActionSheet(title, cancel, destruction, buttons);

			if (afterHideCallback != null)
			{
				afterHideCallback(result);
			}
        }

		public async Task ShowActionSheet(string title, string cancel, string[] buttons, Action<string> afterHideCallback)
		{
			var result = await _dialogPage.DisplayActionSheet(title, cancel, null, buttons);

			if (afterHideCallback != null)
			{
				afterHideCallback(result);
			}
		}

		public async Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
		{
			await _dialogPage.DisplayAlert(title, message, buttonText);

			if (afterHideCallback != null)
			{
				afterHideCallback();
			}
		}

		public async Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
		{
			await _dialogPage.DisplayAlert(title, error.Message, buttonText);

			if (afterHideCallback != null)
			{
				afterHideCallback();
			}
		}

		public async Task ShowError(string message, string title, string cancelText, string retryText, Action<bool> afterHideCallback)
		{
			var result = await _dialogPage.DisplayAlert(title, message, retryText, cancelText);

			if (afterHideCallback != null)
			{
				afterHideCallback(result);
			}
		}

		public async Task ShowError(Exception error, string title, string cancelText, string retryText, Action<bool> afterHideCallback)
		{
			var result = await _dialogPage.DisplayAlert(title, error.Message, retryText, cancelText);

			if (afterHideCallback != null)
			{
				afterHideCallback(result);
			}
		}

		public async Task ShowMessage(string message, string title)
		{
			await _dialogPage.DisplayAlert(title, message, "OK");
		}

		public async Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
		{
			await _dialogPage.DisplayAlert(title, message, buttonText);

			if (afterHideCallback != null)
			{
				afterHideCallback();
			}
		}

		public async Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
		{
			var result = await _dialogPage.DisplayAlert(title, message, buttonConfirmText, buttonCancelText);

			if (afterHideCallback != null)
			{
				afterHideCallback(result);
			}

			return result;
		}

		public async Task ShowMessageBox(string message, string title)
		{
			await _dialogPage.DisplayAlert(title, message, "OK");
		}
	}
}

