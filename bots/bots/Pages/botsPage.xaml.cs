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
			zoekbtn.Clicked += detail;
		}

		async void detail(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new DetailPieChart().GetPageWithPieChart());

		}
}
}
