using System;
using bots;
using bots.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchEntry), typeof(SearchEntryRenderer))]
namespace bots.iOS
{
	public class SearchEntryRenderer : EntryRenderer
	{
		public SearchEntryRenderer()
		{
		}
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			Control.BorderStyle = UIKit.UITextBorderStyle.None;
		}
	}
}
