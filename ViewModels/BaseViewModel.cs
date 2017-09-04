using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using MvvmLight.Services;

namespace MvvmLight.ViewModels
{
	public abstract class BaseViewModel : ViewModelBase
	{
		/* 
         * Define Fields
         */
		protected readonly INavigationService _navigationService;

		private bool _isLoading;
		private bool _isEnabled;
		private string _title;
		private ObservableCollection<string> _errors;

		/* 
         * Define Properties
         */
		public bool IsLoading
		{
			get
			{
				return _isLoading;
			}
			set
			{
				Set(() => IsLoading, ref _isLoading, value);
			}
		}

		public bool IsEnabled
		{
			get
			{
				return _isEnabled;
			}
			set
			{
				Set(() => IsEnabled, ref _isEnabled, value);
			}
		}

		public ObservableCollection<string> Errors
		{
			get
			{
				return _errors;
			}
			set
			{
				Set(() => Errors, ref _errors, value);
			}
		}

		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				Set(() => Title, ref _title, value);
			}
		}

		/*
         * Define Commands
         */
		// TODO:

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MvvmLight.ViewModels.BaseViewModel"/> class.
		/// </summary>
		/// <param name="navigationService">Navigation service.</param>
		public BaseViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;

			IsEnabled = true;
			IsLoading = false;
		}

		/*
         * Define Methods
         */
		public override void Cleanup()
		{
			base.Cleanup();
			Errors = null;
		}
	}
}
