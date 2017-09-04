using System;
using System.Collections.Generic;
using MvvmLight.Models;
using Xamarin.Forms;

namespace MvvmLight.Views
{
    public partial class SamplePage : ContentPage
    {
        // Default constructor keeps Forms Previewer happy and covers us in the event no parameter is passed
        public SamplePage()
        {
            InitializeComponent();
        }

        public SamplePage(CopyItem parameter = null)
        {
            InitializeComponent();

            // Check that our BindingContext exists, then assign the value(s) as appropriate
            var viewModel = this.BindingContext as ViewModels.SamplePageViewModel;
            if(viewModel != null && parameter != null)
            {
                viewModel.Subject = parameter.Title;
                viewModel.Copy = parameter.Body;
            }
        }
    }
}
