using System;
using Android.Graphics;
using bots;
using bots.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(h1Label), typeof(h1LabelRenderer))]
namespace bots.Droid
{
	public class h1LabelRenderer : LabelRenderer
	{
		public h1LabelRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (!string.IsNullOrEmpty(e.NewElement?.StyleId))
			{
				var font = Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, "OpenSans-Bold" + ".ttf");

				Control.Typeface = font;
			}
		}
	}
}



