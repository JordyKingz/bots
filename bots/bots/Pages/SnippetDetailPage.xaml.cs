using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace bots
{
	public partial class SnippetDetailPage : ContentPage
	{
		bool left = false;
		public SnippetDetailPage()
		{
			InitializeComponent();

			verzendbtn.Clicked += Verzendbtn_Clicked;
		}

		async void  Verzendbtn_Clicked(object sender, EventArgs e)
		{
			
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
