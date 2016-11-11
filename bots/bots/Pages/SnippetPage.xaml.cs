using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace bots
{
	public partial class SnippetPage : ContentPage
	{
		bool left = false;
		public SnippetPage()
		{
			InitializeComponent();

			if(App.snip.text != ""){
				snipText.Text = App.snip.text;
			}

		}

		async void OnTapGestureRedTapped(object sender, EventArgs e)
		{
			App.review = 0;
			await Navigation.PushAsync(new SnippetDetailPage());
		}

		async void OnTapGestureBlueTapped(object sender, EventArgs e)
		{
			App.review = 1;
			await Navigation.PushAsync(new DetailPieChart().GetPageWithPieChart());
		}


		async void OnTapGestureGreenTapped(object sender, EventArgs e)
		{
			App.review = 2;
			await Navigation.PushAsync(new DetailPieChart().GetPageWithPieChart());
		}
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			left = true;


		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (left == true)
			{
				Navigation.PopToRootAsync();
			}
		}


	}
}
