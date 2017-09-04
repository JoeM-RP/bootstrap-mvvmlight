using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MvvmLight.Services;

namespace MvvmLight.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
		/*
         * Define Fields
         */
		// TODO: this is a good place to define services that will be initialized or injected in the constructor

		/*
         * Define Properites
         */
		private string _settingOne;
        public string SettingOne
		{
			get
			{
				return _settingOne;
			}
			set
			{
				Set(() => SettingOne, ref _settingOne, value);
			}
		}

        private bool _settingTwo;
        public bool SettingTwo
		{
			get
			{
				return _settingTwo;
			}
			set
			{
				Set(() => SettingTwo, ref _settingTwo, value);
			}
		}

        private bool _settingThree;
        public bool SettingThree
		{
			get
			{
				return _settingThree;
			}
			set
			{
				Set(() => SettingThree, ref _settingThree, value);
			}
		}

		/*
         * Define Commands
         */
		public RelayCommand SaveCommand { get; set; }

        public SettingsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Settings";

            SaveCommand = new RelayCommand( async () =>  await SaveAndNavigate(), () => !IsLoading );
        }

        /*
         * Define Methods
         */
        private async Task<bool> SaveAndNavigate()
        {
            IsLoading = true;

            // TODO: do something to save settings here.
            await Task.Delay(2000).ContinueWith(_ =>
            {
                IsLoading = false;

                this._navigationService.GoBack();
            });
            //\

            return true;
        }
	}
}
