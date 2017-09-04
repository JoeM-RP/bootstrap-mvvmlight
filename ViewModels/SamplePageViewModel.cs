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
		private string _copy = "I’m Joe; full-time developer, part-time hobby-jogger, Tsar of awful check-in comments. I like cooking, exploring Chicago, and a good story. I write code sometimes.";
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
