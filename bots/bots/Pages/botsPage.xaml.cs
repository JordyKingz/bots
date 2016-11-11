using System;
using CrossPieCharts.FormsPlugin.Abstractions;
using Xamarin.Forms;

namespace bots
{
	public partial class botsPage : ContentPage
	{
		

		public botsPage()
		{
			InitializeComponent();
			zoekveld.Completed += (object sender, EventArgs e) => OnPropertyChanged();;
			zoekbtn.Clicked += detail;
		}

		async void detail(object sender, EventArgs e)
		{
			if (zoekveld.Text != "")
			{
				if (App.dat.Count != 0)
				{
					OnPropertyChanged();
					//await Navigation.PushAsync(new DetailPieChart().GetPageWithPieChart());
					await Navigation.PushAsync(new SnippetPage());
				}
				else {
					await DisplayAlert("Geen voorwaarde", "Er zijn geen voorwaarden gevonden. Contreel het ingevulde URL.", "OK");
				}
			}
			else {
				await DisplayAlert("Vul URL in", "Vul een URL in om verder te gaan.", "OK");
			}
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			//App.dat.Clear();
		}
}
}
