using System;
using bots;
using bots.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(SearchEntry),typeof(SearchEntryRenderer))]
namespace bots.Droid
{
	public class SearchEntryRenderer : EntryRenderer
	{
		public SearchEntryRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
		}
	}
}
