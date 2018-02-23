/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:OnionTemplate" x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  BindingContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MvvmLight.ViewModels;

namespace MvvmLight.Startup
{
	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// </summary>
	public class ViewModelLocator
	{
		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		static ViewModelLocator()
		{
			var iocConfig = new IoCConfig();
			iocConfig.RegisterSettings();
			iocConfig.RegisterRepositories();
			iocConfig.RegisterServices();
			iocConfig.RegisterViewModels();
			iocConfig.RegisterNavigation();
		}

		public static void Cleanup()
		{
			// TODO Clear the ViewModels
		}

		/* 
         * Define ViewModels
         */
		public HomePageViewModel HomePage => ServiceLocator.Current.GetInstance<HomePageViewModel>();
		public MenuPageViewModel MenuPage => ServiceLocator.Current.GetInstance<MenuPageViewModel>();
        public SamplePageViewModel SamplePage => ServiceLocator.Current.GetInstance<SamplePageViewModel>();
        public SettingsPageViewModel SettingsPage => ServiceLocator.Current.GetInstance<SettingsPageViewModel>();

		// TODO INIT: Add new ViewModels Here
	}
}
