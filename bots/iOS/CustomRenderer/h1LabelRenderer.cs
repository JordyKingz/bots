using System;
using bots;
using bots.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(h1Label), typeof(h1LabelRenderer))]
namespace bots.iOS
{
	public class h1LabelRenderer : LabelRenderer
	{
		public h1LabelRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);
		}
	}
}
