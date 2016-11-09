using System;
using bots;
using bots.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton),typeof(CustomButtonRenderer))]
namespace bots.Droid
{
	public class CustomButtonRenderer : ButtonRenderer
	{
		public CustomButtonRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			Control.SetPadding(0, 10, 0, 10);
		}
	}
}
