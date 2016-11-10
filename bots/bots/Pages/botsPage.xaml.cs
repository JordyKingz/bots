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
				await Navigation.PushAsync(new DetailPieChart().GetPageWithPieChart());
			}
			else {
				await DisplayAlert("Vul URL in", "Vul een URL in om verder te gaan.", "OK");
			}
		}
}
}
