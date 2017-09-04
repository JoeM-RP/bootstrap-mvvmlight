using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using MvvmLight.Models;
using MvvmLight.Services;

namespace MvvmLight.ViewModels
{
	public class HomePageViewModel : BaseViewModel
	{
        /*
         * Define Fields
         */
        private IDialogService _dialogService;

		/*
         * Define Properites
         */
		private ObservableCollection<CopyItem> _copyItems = new ObservableCollection<CopyItem>();
        public ObservableCollection<CopyItem> CopyItems
		{
			get
			{
				return _copyItems;
			}
			set
			{
				Set(() => CopyItems, ref _copyItems, value);
			}
		}

		private CopyItem _selectedItem;
		public CopyItem SelectedItem
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
			}
		}

		/*
         * Define Commands
         */
        public RelayCommand ShowActionSheetCommand { get; set; }
        public RelayCommand ShowAlertCommand { get; set; }
        public RelayCommand<CopyItem> SelectItemCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService, IDialogService dialogService) : base(navigationService)
        {
			this.Title = "Home";
            _dialogService = dialogService;

            ShowAlertCommand = new RelayCommand(async () => await ShowAlert());
            ShowActionSheetCommand = new RelayCommand(async () => await ShowActionSheet());
            SelectItemCommand = new RelayCommand<CopyItem>((param) => Navigate(param));

            Init();
		}

		/*
         * Define Methods
         */
        private async Task ShowAlert()
        {
            await _dialogService.ShowError("This is a fake error to demonstrate the alert", "Yikes!", "Cancel", "Retry", response => 
            {
                if(response)
                {
                    // TODO: If response is true, the user wants to "retry" the action. 
                    // Do something here to attempt the action again
                }
                else
                {
                    // TODO: If response is false, the user has canceled the attempted action
                    // So perform an action here that makes sense; we may want to naviagte to 
                    // a previous page or just sit idle
                }
            });
        }

        private async Task ShowActionSheet()
        {
            await _dialogService.ShowActionSheet("Actions", "Cancel", "Exit", new string[] { "Action1", "Action2" }, response =>
            {
                // TODO: Like with the Error Dialog, we want to perform different actions based on the user selection
                switch(response)
                {
                    case("Action1"):
                    case("Action2"):
                    default:
                        _dialogService.ShowMessage($"Selected {response}", "I did it!");
                        break;
                }

            });

        }

        private void Navigate(CopyItem parameter)
        {
            this._navigationService.NavigateTo(nameof(Views.SamplePage), parameter);
        }

        private void Init()
        {
            _copyItems.Add(new CopyItem()
            {
                Title = "About Me",
                Body = "I’m Joe; full-time developer, part-time hobby-jogger, Tsar of awful check-in comments. I like cooking, exploring Chicago, and a good story. I write code sometimes."
            });

            _copyItems.Add(new CopyItem()
            {
                Title = "About MvvmLight",
                Body = "The main purpose of the toolkit is to accelerate the creation and development of MVVM applications in WPF, Silverlight, Windows Store, Windows Phone and Xamarin\nGet started\n\nMore information about the MVVM Light Toolkit can be found on http://www.mvvmlight.net."
            });

            _copyItems.Add(new CopyItem()
            {
                Title = "About Shakespeare",
                Body = "William Shakespeare was an English poet, playwright, and actor, widely regarded as the greatest writer in the English language and the world's pre-eminent dramatist. He is often called England's national poet, and the \"Bard of Avon\". His extant works, including collaborations, consist of approximately 38 plays, 154 sonnets, 2 long narrative poems, and a few other verses, some of uncertain authorship. His plays have been translated into every major living language and are performed more often than those of any other playwright."
            });

        }
	}
}