using System;

namespace MvvmLight.Services
{
	/// <summary>
	/// Navigation service that extends <see cref="GalaSoft.MvvmLight.Views.INavigationService"/>. Add any
    /// navigatioon techniques you need that aren't part of the MvvmLight interface here
	/// </summary>
	public interface INavigationService : GalaSoft.MvvmLight.Views.INavigationService
	{
		void GoBackToRoot();
	}
}
