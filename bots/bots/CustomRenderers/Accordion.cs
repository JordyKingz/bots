using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace bots
{
	public class AccordionButton : Button
	{
		#region Private Variables
		bool mExpand = false;
		#endregion
		public AccordionButton()
		{
			HorizontalOptions = LayoutOptions.FillAndExpand;
			BorderColor = Color.Black;
			BorderRadius = 5;
			BorderWidth = 0;
		}
		#region Properties
		public bool Expand
		{
			get { return mExpand; }
			set { mExpand = value; }
		}
		public ContentView AssosiatedContent
		{ get; set; }
		#endregion
	}

	public class AccordionSource
	{
		public string HeaderText { get; set; }
		public Color HeaderTextColor { get; set; }
		public Color HeaderBackGroundColor { get; set; }
		public Color LeftBorderColor { get; set; }
		public View ContentItems { get; set; }
	}

	public class Accordion : ContentView
	{
		#region Private Variables
		List<AccordionSource> mDataSource;
		bool mFirstExpaned = false;
		StackLayout mMainLayout;
		#endregion


		public Accordion()
		{
			var mMainLayout = new StackLayout();
			Content = mMainLayout;
		}
		public Accordion(List<AccordionSource> aSource)
		{
			mDataSource = aSource;
			DataBind();
		}
		#region Properties
		public List<AccordionSource> DataSource
		{
			get { return mDataSource; }
			set { mDataSource = value; }
		}
		public bool FirstExpaned
		{
			get { return mFirstExpaned; }
			set { mFirstExpaned = value; }
		}
		#endregion



		public void DataBind()
		{
			var vMainLayout = new StackLayout();
			var vFirst = true;
			if (mDataSource != null)
			{
				foreach (var vSingleItem in mDataSource)
				{

					var vHeaderButton = new AccordionButton()
					{
						Text = vSingleItem.HeaderText,
						TextColor = vSingleItem.HeaderTextColor,
						BackgroundColor = Color.Transparent


					};

					var vAccordionContent = new ContentView()
					{
						Content = vSingleItem.ContentItems,
						IsVisible = false
					};
					if (vFirst)
					{
						vHeaderButton.Expand = mFirstExpaned;
						vAccordionContent.IsVisible = mFirstExpaned;
						vFirst = false;
					}

					vHeaderButton.AssosiatedContent = vAccordionContent;
					vHeaderButton.Clicked += OnAccordionButtonClicked;

					var stack = new StackLayout();
					var stroke = new StackLayout();
					stack.Orientation = StackOrientation.Horizontal;
					stack.BackgroundColor = vSingleItem.HeaderBackGroundColor;
					stroke.WidthRequest = 6;
					stroke.HeightRequest = 25;
					stroke.BackgroundColor = vSingleItem.LeftBorderColor;

					stack.Children.Add(stroke);
					stack.Children.Add(vHeaderButton);


					vMainLayout.Children.Add(stack);
					//vMainLayout.Children.Add(vHeaderButton);
					vMainLayout.Children.Add(vAccordionContent);

				}
			}
			mMainLayout = vMainLayout;
			Content = mMainLayout;
		}

		void OnAccordionButtonClicked(object sender, EventArgs args)
		{
			foreach (var vChildItem in mMainLayout.Children)
			{
				if (vChildItem.GetType() == typeof(ContentView)) vChildItem.IsVisible = false;
				if (vChildItem.GetType() == typeof(AccordionButton))
				{
					var vButton = (AccordionButton)vChildItem;
					vButton.Expand = false;
				}
			}
			var vSenderButton = (AccordionButton)sender;

			if (vSenderButton.Expand)
			{
				vSenderButton.Expand = false;
			}
			else vSenderButton.Expand = true;
			vSenderButton.AssosiatedContent.IsVisible = vSenderButton.Expand;
		}

	}
	public class ListDataViewCell : ViewCell
	{
		public ListDataViewCell()
		{
			var label = new Label()
			{
				Font = Font.SystemFontOfSize(NamedSize.Default),
				TextColor = Color.Blue
			};
			label.SetBinding(Label.TextProperty, new Binding("TextValue"));
			label.SetBinding(Label.ClassIdProperty, new Binding("DataValue"));
			View = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(12, 8),
				Children = { label }
			};
		}
	}

	public class SimpleObject
	{
		public string TextValue { get; set; }
		public string DataValue { get; set; }
	}
}
