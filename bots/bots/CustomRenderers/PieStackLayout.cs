using System;
using CrossPieCharts.FormsPlugin.Abstractions;
using Xamarin.Forms;

namespace bots
{
	public class PieStackLayout 
	{
		private StackLayout view;



		public PieStackLayout()
		{
			view = new StackLayout
			{
				Children =
							{
								new Label
								{
									XAlign = TextAlignment.Center,
									Text = "Welcome to Xamarin Forms!",
									TextColor = Color.Black
								},
								new Grid
								{
									Children =
									{
										new CrossPieChartView
										{
											Progress = 80,
											ProgressColor = Color.Red,
											ProgressBackgroundColor = Color.FromHex("#EEEEEEEE"),
											StrokeThickness = Device.OnPlatform(10, 20, 80),
											Radius = Device.OnPlatform(100, 180, 160),
											BackgroundColor = Color.White
										},
										new CrossPieChartView
										{
											Progress = 60,
											ProgressColor = Color.Green,
											ProgressBackgroundColor = Color.Transparent,
											StrokeThickness = Device.OnPlatform(10, 20, 80),
											Radius = Device.OnPlatform(100, 180, 160),
											BackgroundColor = Color.Transparent
										},
										new Label
										{
											Text = "60%",
											Font = Font.BoldSystemFontOfSize(NamedSize.Large),
											FontSize = 70,
											VerticalOptions = LayoutOptions.Center,
											HorizontalOptions = LayoutOptions.Center,
											TextColor = Color.Black
										}
									}
					}}
			};

		}

	}
}
