using System;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MvvmLight.Services;

namespace MvvmLight.Startup
{
	/// <summary>
	/// Managing class for registering dependencies 
	/// Notes: You can change these registrations or add on to them in the native environments to inject native implementations
	/// You can also change these registrations in test projects to use test data with Dependency Injection
	/// </summary>
	public class IoCConfig
	{
		public IoCConfig()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
		}

		public void RegisterSettings()
		{
			//SimpleIoc.Default.Register<IClientSettings, ClientSettings>();
		}

		public void RegisterRepositories()
		{
            // TODO:
		}

		public void RegisterServices()
		{
            //TODO:
		}

		/// <summary>
		/// Registers the view models.
		/// </summary>
		public void RegisterViewModels()
		{
			SimpleIoc.Default.Register<ViewModels.HomePageViewModel>();
			SimpleIoc.Default.Register<ViewModels.MenuPageViewModel>();
			SimpleIoc.Default.Register<ViewModels.SamplePageViewModel>();
			SimpleIoc.Default.Register<ViewModels.SettingsPageViewModel>();

			// TODO INIT: Register new ViewModels here
		}

		/// <summary>
		/// Handles navigation wire up
		/// </summary>
		public void RegisterNavigation()
		{
			var navigationService = new NavigationService();
			navigationService.Configure(nameof(Views.HomePage), typeof(Views.HomePage));
			navigationService.Configure(nameof(Views.MenuPage), typeof(Views.MenuPage));
            navigationService.Configure(nameof(Views.SamplePage), typeof(Views.SamplePage));
            navigationService.Configure(nameof(Views.SettingsPage), typeof(Views.SettingsPage));

			// TODO INIT: Register new Views here

			SimpleIoc.Default.Register<INavigationService>(() => navigationService);
		}
	}
}
