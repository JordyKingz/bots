using System;
using System.Collections.Generic;
using CrossPieCharts.FormsPlugin.Abstractions;
using Xamarin.Forms;

namespace bots
{
	public partial class App : Application
	{
		public class Snippet
		{
			public int guid;
			public int snippetId;
			public string text;
		}



		public class Data
		{
			public String name;
			public List<Problems> problems;
			public List<Paragraphs> paragraphs;
		}
		public class Problems
		{
			public String tag;
			public String msg;
			public String weight;

		}

		public class Paragraphs
		{
			public String text;
			public String weight;
		}
		public static List<Data>  dat = new List<Data>();
		public static Snippet snip;
		public static int review;
		public static string reviewComment;


		public App()
		{
			InitializeComponent();
			var _controller = new NavigationPage(new botsPage());
			_controller.BarBackgroundColor = Color.FromHex("#4A004F");
			_controller.BarTextColor = Color.FromHex("#fafafa");
			_controller.SetValue(NavigationPage.BarTextColorProperty, Color.White);
			MainPage = _controller;
			//standaard geen review meegeven
			review = 3;


			//MainPage = _controller;
			var _tab = new Mainpage();
			//_tab.CurrentPage = _tab.Children[1];
			var _nav = new NavigationPage(_tab);
			_nav.BarBackgroundColor = Color.FromHex("#4A004F");
			_nav.BarTextColor = Color.FromHex("#fafafa");
			_nav.SetValue(NavigationPage.BarTextColorProperty, Color.White);
			//MainPage = _nav;

			//MainPage = new DetailPieChart().GetPageWithPieChart();

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
