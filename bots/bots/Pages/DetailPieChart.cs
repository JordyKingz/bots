using System;
using CrossPieCharts.FormsPlugin.Abstractions;
using Xamarin.Forms;

namespace bots
{
	public class DetailPieChart
	{
		public DetailPieChart()
		{
		}



		public ContentPage GetPageWithPieChart()
		{
			// The root page of your application

			var contentPage = new ContentPage
			{
				Content = new ScrollView()
				{
					Content = new Grid
					{
						Children =
					{
						new Grid // a trick to set the BackgroundColor of the ContentPage to white
                        {
							BackgroundColor  = Color.White,
						},
						new StackLayout
						{
							Children =
							{

								new Grid
									{  Padding = new Thickness(20,20,20,20), 
									Children =
									{
										new CrossPieChartView
										{
											Progress = 100,
											ProgressColor = Color.Red,
											ProgressBackgroundColor = Color.FromHex("#EEEEEEEE"),
											StrokeThickness = Device.OnPlatform(10, 20, 80),
											Radius = Device.OnPlatform(100, 180, 160),
											BackgroundColor = Color.White
										},
										new CrossPieChartView
										{
											Progress = 80,
											ProgressColor = Color.FromHex("#Ffa500"),
											ProgressBackgroundColor = Color.Transparent,
											StrokeThickness = Device.OnPlatform(10, 20, 80),
											Radius = Device.OnPlatform(100, 180, 160),
											BackgroundColor = Color.Transparent
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
											TextColor = Color.Green
										}
									}
							},
									new StackLayout
									{
										HorizontalOptions = LayoutOptions.CenterAndExpand,
										Orientation = StackOrientation.Horizontal,

										Children = {

											new StackLayout
											{
												Padding = new Thickness (20,0,20,0),
												Orientation = StackOrientation.Vertical,
												Children =
												{
													new Label
													{
														Text = "Privacy",
														Font = Font.BoldSystemFontOfSize(NamedSize.Large),
														FontSize = 14,
														VerticalOptions = LayoutOptions.Center,
														HorizontalOptions = LayoutOptions.Center,
														TextColor = Color.Black
													},
													new Label
													{
														Text = "60%",
														Font = Font.BoldSystemFontOfSize(NamedSize.Large),
														FontSize = 14,
														VerticalOptions = LayoutOptions.Center,
														HorizontalOptions = LayoutOptions.Center,
														TextColor = Color.FromHex("#FFa500")
													}
												},







											},new StackLayout
											{
												Orientation = StackOrientation.Vertical,
												Padding = new Thickness (20,0,20,0),

												Children =
												{
													new Label
													{
														Text = "Garantie",
														Font = Font.BoldSystemFontOfSize(NamedSize.Large),
														FontSize = 14,
														VerticalOptions = LayoutOptions.Center,
														HorizontalOptions = LayoutOptions.Center,
														TextColor = Color.Black
													},
													new Label
													{
														Text = "90%",
														Font = Font.BoldSystemFontOfSize(NamedSize.Large),
														FontSize = 14,
														VerticalOptions = LayoutOptions.Center,
														HorizontalOptions = LayoutOptions.Center,
														TextColor = Color.Green
													}
												}

											},new StackLayout
											{
												Orientation = StackOrientation.Vertical,
												Padding = new Thickness (20,0,20,0),

												Children =
												{
													new Label
													{
														Text = "Aansprakelijkheid",
														Font = Font.BoldSystemFontOfSize(NamedSize.Large),
														FontSize = 14,
														VerticalOptions = LayoutOptions.Center,
														HorizontalOptions = LayoutOptions.Center,
														TextColor = Color.Black
													},
													new Label
													{
														Text = "10%",
														Font = Font.BoldSystemFontOfSize(NamedSize.Large),
														FontSize = 14,
														VerticalOptions = LayoutOptions.Center,
														HorizontalOptions = LayoutOptions.Center,
														TextColor = Color.Red
													}
												}

											}


										}

									}

						}
					}
				}
				}
				}
			
            };


			return contentPage;
		}
	}
}
