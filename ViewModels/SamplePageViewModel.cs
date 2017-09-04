using System;
using GalaSoft.MvvmLight.Command;
using MvvmLight.Services;

namespace MvvmLight.ViewModels
{
    public class SamplePageViewModel : BaseViewModel
    {
		/*
         * Define Fields
         */
		// TODO: this is a good place to define services that will be initialized or injected in the constructor

		/*
         * Define Properites
         */
		private string _subject;
		public string Subject
		{
			get
			{
				return _subject;
			}
			set
			{
				Set(() => Subject, ref _subject, value);
			}
		}

        private string _copy;
        public string Copy
		{
			get
			{
				return _copy;
			}
			set
			{
				Set(() => Copy, ref _copy, value);
			}
		}

		/*
         * Define Commands
         */
		public RelayCommand NavigateCommand { get; set; }

        public SamplePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Sample Page";
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
