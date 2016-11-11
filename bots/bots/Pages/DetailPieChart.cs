using System;
using System.Collections.Generic;
using System.Linq;
using CrossPieCharts.FormsPlugin.Abstractions;
using Xamarin.Forms;

namespace bots
{
	public class DetailPieChart
	{
		public DetailPieChart()
		{
		}

		public class problem
		{
			public string name;
			public int highWeight;
		}



		public ContentPage GetPageWithPieChart()
		{
			
			
			// The root page of your application
			List<App.Data> data = App.dat;

			var countProblems = 12 - data.Count;
			var oranjePercentage = 0;
			Decimal groenPercentage = (countProblems / 12m) * 100m;


			List<problem> allProblems = new List<problem>();

			for (var i = 0; i < data.Count; i++)
			{

				problem prob = new problem();
				List<int> weights = new List<int>();
				for (var a = 0; a < data[i].problems.Count; a++)
				{


					weights.Add(Convert.ToInt32(data[i].problems[a].weight));


				}
				var max = weights.Max();
				//System.Diagnostics.Debug.WriteLine(max);
				prob.name = data[i].name;
				prob.highWeight = max;
				allProblems.Add(prob);

			}

			foreach (problem prob in allProblems)
			{
				if (prob.highWeight < 66 && prob.highWeight > 0)
				{
					System.Diagnostics.Debug.WriteLine(prob.highWeight);
					oranjePercentage = oranjePercentage + 1;
				}
			}

			Decimal orange = (oranjePercentage / 12m) * 100m;
			Decimal opvallend = orange;
			Decimal roodPercentge = 100 - groenPercentage - orange;
			orange = orange + groenPercentage;


			//System.Diagnostics.Debug.WriteLine(oranjePercentage);

			var accordion = new StackLayout();
			var vAccordionSource = GetAccordionData();
			var vAccordionControl = new Accordion(vAccordionSource);
			accordion.Children.Add(vAccordionControl);

			var contentPage = new ContentPage
			{ Title="Resultaten",
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
										{Progress = Convert.ToInt32( orange),
											ProgressColor = Color.FromHex("#Ffa500"),
											ProgressBackgroundColor = Color.Transparent,
											StrokeThickness = Device.OnPlatform(10, 20, 80),
											Radius = Device.OnPlatform(100, 180, 160),
											BackgroundColor = Color.Transparent
										},
										new CrossPieChartView
											{   Progress = Convert.ToInt32( groenPercentage),
											ProgressColor = Color.Green,
											ProgressBackgroundColor = Color.Transparent,
											StrokeThickness = Device.OnPlatform(10, 20, 80),
											Radius = Device.OnPlatform(100, 180, 160),
											BackgroundColor = Color.Transparent
										},
										new Label
										{
												Text = Convert.ToInt32(groenPercentage) +"%",
											Font = Font.BoldSystemFontOfSize(NamedSize.Large),
											FontSize = 70,
											VerticalOptions = LayoutOptions.Center,
											HorizontalOptions = LayoutOptions.Center,
											TextColor = Color.Green
										},new CrossPieChartView
										{
											Progress = 0,
											ProgressColor = Color.Red,
											ProgressBackgroundColor = Color.Transparent,
											StrokeThickness = Device.OnPlatform(10, 20, 80),
											Radius = Device.OnPlatform(100, 180, 160),
											BackgroundColor = Color.Transparent
										},
									}
							},
									new StackLayout
									{
										HorizontalOptions = LayoutOptions.CenterAndExpand,
										Orientation = StackOrientation.Horizontal, Margin = new Thickness(0,0,0,20),

										Children = {

											new StackLayout
											{
												Padding = new Thickness (20,0,20,0),
												Orientation = StackOrientation.Vertical,
												Children =
												{
													new Label
													{
														Text = "Veilig",
														Font = Font.BoldSystemFontOfSize(NamedSize.Large),
														FontSize = 14,
														VerticalOptions = LayoutOptions.Center,
														HorizontalOptions = LayoutOptions.Center,
														TextColor = Color.Black
													},
													new Label
													{
														Text = Convert.ToInt32(groenPercentage) + "%",
														Font = Font.BoldSystemFontOfSize(NamedSize.Large),
														FontSize = 14,
														VerticalOptions = LayoutOptions.Center,
														HorizontalOptions = LayoutOptions.Center,
														TextColor = Color.Green
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
														Text = "Opvallend",
														Font = Font.BoldSystemFontOfSize(NamedSize.Large),
														FontSize = 14,
														VerticalOptions = LayoutOptions.Center,
														HorizontalOptions = LayoutOptions.Center,
														TextColor = Color.Black
													},
													new Label
													{
														Text = Convert.ToInt32(opvallend) + "%",
														Font = Font.BoldSystemFontOfSize(NamedSize.Large),
														FontSize = 14,
														VerticalOptions = LayoutOptions.Center,
														HorizontalOptions = LayoutOptions.Center,
														TextColor = Color.FromHex("#FFa500")
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
														Text = "Risicovol",
														Font = Font.BoldSystemFontOfSize(NamedSize.Large),
														FontSize = 14,
														VerticalOptions = LayoutOptions.Center,
														HorizontalOptions = LayoutOptions.Center,
														TextColor = Color.Black
													},
													new Label
													{
														Text = Convert.ToInt32(roodPercentge) +"%",
														Font = Font.BoldSystemFontOfSize(NamedSize.Large),
														FontSize = 14,
														VerticalOptions = LayoutOptions.Center,
														HorizontalOptions = LayoutOptions.Center,
														TextColor = Color.Red
													}
												}

											}


										}

									}, accordion

						}
					}
				}
					}
				}

			};


			return contentPage;
		}
		public List<AccordionSource> GetAccordionData()
		{
			var vResult = new List<AccordionSource>();



			#region Second List
			var vListTwo = new List<SimpleObject>();
			var vObjectRavi = new SimpleObject()
			{
				TextValue = "S Ravi Kumar",
				DataValue = "1"
			};
			vListTwo.Add(vObjectRavi);
			var vObjectFather = new SimpleObject()
			{
				TextValue = "Father",
				DataValue = "2"
			};
			vListTwo.Add(vObjectFather);
			var vObjectTrainer = new SimpleObject()
			{
				TextValue = "Trainer",
				DataValue = "2"
			};
			vListTwo.Add(vObjectTrainer);
			var vObjectConsultant = new SimpleObject()
			{
				TextValue = "Consultant",
				DataValue = "2"
			};
			vListTwo.Add(vObjectConsultant);
			var vObjectArchitect = new SimpleObject()
			{
				TextValue = "Architect",
				DataValue = "2"
			};
			vListTwo.Add(vObjectArchitect);

			var vListViewTwo = new ListView()
			{
				ItemsSource = vListTwo,
				ItemTemplate = new DataTemplate(typeof(ListDataViewCell))
			};

			#endregion

			#region StackLayout

			List<App.Data> data = App.dat;

			for (var i = 0; i < data.Count; i++)
			{
				var vViewLayout = new StackLayout()
				{
					
					Margin = new Thickness(20)

				};
				List<int> weights = new List<int>();
				for (var a = 0; a < data[i].paragraphs.Count; a++)
				{

					var label = new Label { Text = data[i].paragraphs[a].text, TextColor = Color.Black, Margin = new Thickness(0,15,0,15) };
					weights.Add(Convert.ToInt32(data[i].problems[a].weight));
					vViewLayout.Children.Add(label);
				}
				var max = weights.Max();
				Color color;
				if (max < 66 && max > 0)
				{
					color = Color.FromHex("#FFa500");
				}
				else {
					color = Color.Red;
				}


				#endregion
				var vSecond = new AccordionSource()
				{
					HeaderText = data[i].name,
					HeaderTextColor = Color.Black,
					HeaderBackGroundColor = Color.FromHex("#fafafa"),
					LeftBorderColor = color ,
					ContentItems = vViewLayout
				};
				vResult.Add(vSecond);

			}

			return vResult;
		}
	}
}



