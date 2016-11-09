using System;
using Android.Graphics;
using bots;
using bots.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace bots.Droid
{
	public class CustomLabelRenderer : LabelRenderer
	{
		public CustomLabelRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (!string.IsNullOrEmpty(e.NewElement?.StyleId))
			{
				var font = Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, "OpenSans-Regular" + ".ttf");

				Control.Typeface = font;
			}
		}
	}
}
