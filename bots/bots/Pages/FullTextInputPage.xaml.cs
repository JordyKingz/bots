using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace bots
{
	public partial class FullTextInputPage : ContentPage
	{
		public FullTextInputPage()
		{
			InitializeComponent();

			verzendbtn.Clicked += Verzendbtn_Clicked;
		}

		async void Verzendbtn_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SnippetPage());
		}
	}
}
