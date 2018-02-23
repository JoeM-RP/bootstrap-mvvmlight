using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using MvvmLight.Models;
using MvvmLight.Services;

namespace MvvmLight.ViewModels
{
	public class MenuPageViewModel : BaseViewModel
	{
		/*
         * Define Fields
         */
		// TODO: this is a good place to define services that will be initialized or injected in the constructor

		/*
         * Define Properties
         */
		private ObservableCollection<NavigationMenuItem> _menuItems = new ObservableCollection<NavigationMenuItem>();
		public ObservableCollection<NavigationMenuItem> MenuItems
		{
			get
			{
				return _menuItems;
			}
			set
			{
				Set(() => MenuItems, ref _menuItems, value);
			}
		}

		private NavigationMenuItem _selectedItem;
		public NavigationMenuItem SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				Set(() => SelectedItem, ref _selectedItem, value);
				if (_selectedItem == null)
					return;
				this.SelectItemCommand.Execute(value);
				SelectedItem = null;
				Xamarin.Forms.MessagingCenter.Send(this, "CLOSE_MENU");
			}
		}

		/*
         * Define Commands
         */
		public RelayCommand<NavigationMenuItem> SelectItemCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MvvmLight.ViewModels.MenuPageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
		public MenuPageViewModel(INavigationService navigationService) : base(navigationService)
		{
            this.Title = "Mvvm Light Bootstrap";

			// Commands
			SelectItemCommand = new RelayCommand<NavigationMenuItem>((s) => Navigate(s));

			Initialize();
		}

		/* 
         * Define Methods
         */
		private void Initialize()
		{
			MenuItems.Add(new NavigationMenuItem()
			{
				Key = "Home",
				Title = "Home",
                Image = "home.png"
			});

			MenuItems.Add(new NavigationMenuItem()
			{
				Key = "Settings",
				Title = "Settings",
                Image = "settings.png"
			});
		}

		private void Navigate(NavigationMenuItem args)
		{
			var navKey = this._navigationService.CurrentPageKey;

			switch (args.Key)
			{
				case ("Settings"):
                    navKey = nameof(Views.SettingsPage);
					break;
				default:
					this._navigationService.GoBackToRoot();
                    return;
			}

			// Only navigate if it's a different page
			if (navKey != this._navigationService.CurrentPageKey)
				this._navigationService.NavigateTo(navKey);
		}
	}
}
