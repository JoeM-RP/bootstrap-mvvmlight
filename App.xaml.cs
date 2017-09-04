using Xamarin.Forms;

namespace MvvmLight
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MvvmLightPage();
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
