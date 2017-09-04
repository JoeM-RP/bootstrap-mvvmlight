using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using MvvmLight.Services;

namespace MvvmLight.ViewModels
{
	public class HomePageViewModel : BaseViewModel
	{
		/*
         * Define Fields
         */
		// TODO:

		/*
         * Define Properites
         */
		private ObservableCollection<string> _bulletinBoardItems = new ObservableCollection<string>();
		public ObservableCollection<string> BulletinBoardItems
		{
			get
			{
				return _bulletinBoardItems;
			}
			set
			{
				Set(() => BulletinBoardItems, ref _bulletinBoardItems, value);
			}
		}

		private string _selectedItem;
		public string SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				Set(() => SelectedItem, ref _selectedItem, value);
				this.SelectItemCommand.Execute(value);
			}
		}

		/*
         * Define Commands
         */
		public RelayCommand NavigateCommand { get; set; }
        public RelayCommand<string> SelectItemCommand { get; set; }

		public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
			this.Title = "Home";

			NavigateCommand = new RelayCommand(() => Navigate());

            Init();
		}

		/*
         * Define Methods
         */
		private void Navigate()
		{
            this._navigationService.NavigateTo(nameof(Views.SamplePage));
		}

        private void Init()
        {
            
        }
	}
}