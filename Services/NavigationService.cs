using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace MvvmLight.Services
{
	/// <summary>
	/// Service for navigating from the ViewModels
	/// </summary>
	public class NavigationService : INavigationService
	{
		private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();

		private NavigationPage _navigation;
		public NavigationPage Navigation
		{
			get
			{
				return _navigation;
			}
		}

		public string CurrentPageKey
		{
			get
			{
				lock (_pagesByKey)
				{
					if (_navigation.CurrentPage == null)
					{
						return null;
					}

					var pageType = _navigation.CurrentPage.GetType();

					return _pagesByKey.ContainsValue(pageType)
						? _pagesByKey.First(p => p.Value == pageType).Key
						: null;
				}
			}
		}

		public void GoBack()
		{
			_navigation.PopAsync();
		}

		public void GoBackToRoot()
		{
			_navigation.PopToRootAsync();
		}

		public void NavigateTo(string pageKey)
		{
			NavigateTo(pageKey, null);
		}

		public void NavigateTo(string pageKey, object parameter)
		{
			lock (_pagesByKey)
			{
				if (_pagesByKey.ContainsKey(pageKey))
				{
					var type = _pagesByKey[pageKey];
					ConstructorInfo constructor;
					object[] parameters;

					if (parameter == null)
					{
						constructor = type.GetTypeInfo()
							.DeclaredConstructors
							.FirstOrDefault(c => !c.GetParameters().Any());

						parameters = new object[]
						{
						};
					}
					else
					{
						constructor = type.GetTypeInfo()
							.DeclaredConstructors
							.FirstOrDefault(
								c =>
								{
									var p = c.GetParameters();
									return p.Count() == 1
										   && p[0].ParameterType == parameter.GetType();
								});

						parameters = new[]
						{
							parameter
						};
					}

					if (constructor == null)
					{
                        var err = $"No suitable constructor found for page {pageKey}";

						Debug.WriteLine(err);
						if (Debugger.IsAttached) Debugger.Break();

						throw new InvalidOperationException(
							);
					}

					var page = constructor.Invoke(parameters) as Page;
					_navigation.PushAsync(page);
				}
				else
				{
                    var err = $"No such page: {pageKey}. Did you forget to call NavigationService.Configure?";

                    Debug.WriteLine(err);
                    if (Debugger.IsAttached) Debugger.Break();

                    throw new ArgumentException(err, nameof(pageKey));
				}
			}
		}

		public void Configure(string pageKey, Type pageType)
		{
			lock (_pagesByKey)
			{
				if (_pagesByKey.ContainsKey(pageKey))
				{
					_pagesByKey[pageKey] = pageType;
				}
				else
				{
					_pagesByKey.Add(pageKey, pageType);
				}
			}
		}

		public void Initialize(NavigationPage navigation)
		{
			_navigation = navigation;
		}
	}
}