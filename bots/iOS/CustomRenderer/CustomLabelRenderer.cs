using System;
using bots;
using bots.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomLabel),typeof(CustomLabelRenderer))]
namespace bots.iOS
{
	public class CustomLabelRenderer : LabelRenderer
	{
		public CustomLabelRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			Control.Font = UIFont.FromName("OpenSans", 14);
		}
	}
}
