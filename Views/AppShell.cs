using System;
using MvvmLight.ViewModels;
using Xamarin.Forms;

namespace MvvmLight.Views
{
	public class AppShell : MasterDetailPage
	{
		public AppShell()
		{
            Detail = new NavigationPage(new HomePage())
			{
				BarTextColor = Color.White,
				BarBackgroundColor = Color.FromHex("#394A76"),
			};

			Master = new MenuPage()
			{
				Title = "Menu",
			};
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			MessagingCenter.Subscribe<MenuPageViewModel>(this, "CLOSE_MENU", (vm) =>
			{
				if (Device.Idiom != TargetIdiom.Desktop && Device.Idiom != TargetIdiom.Tablet)
				{
					this.IsPresented = false;
				}
			});
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			MessagingCenter.Unsubscribe<MenuPageViewModel>(this, "CLOSE_MENU");
		}
	}
}
