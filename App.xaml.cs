﻿using Microsoft.Practices.ServiceLocation;
using MvvmLight.Services;
using Xamarin.Forms;

namespace MvvmLight
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			var mainPage = new Views.AppShell();

            // Init Navigation Service
			((NavigationService)ServiceLocator.Current.GetInstance<INavigationService>()).Initialize((NavigationPage)mainPage.Detail);
			MainPage = mainPage;

			// Init Dialog Service
			((DialogService)ServiceLocator.Current.GetInstance<IDialogService>()).Initialize(MainPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
