using Xamarin.Forms;

namespace bots
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			var _controller = new NavigationPage(new botsPage());
			_controller.BarBackgroundColor = Color.FromHex("#4A004F");
			_controller.BarTextColor = Color.FromHex("#fafafa");
			_controller.SetValue(NavigationPage.BarTextColorProperty, Color.White);



			MainPage = _controller;
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
