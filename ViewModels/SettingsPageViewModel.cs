using System;
using GalaSoft.MvvmLight.Command;
using MvvmLight.Services;

namespace MvvmLight.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
		/*
         * Define Fields
         */
		// TODO:

		/*
         * Define Properites
         */
		// TODO:

		/*
         * Define Commands
         */
		public RelayCommand NavigateCommand { get; set; }

        public SettingsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Settings";
        }

		/*
         * Define Methods
         */
		private void Navigate()
		{
			this._navigationService.NavigateTo(nameof(Views.SettingsPage));
		}
	}
}
