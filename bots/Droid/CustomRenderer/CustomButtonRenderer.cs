using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using bots;
using bots.Droid;
using Java.Util;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;




[assembly: ExportRenderer(typeof(CustomButton),typeof(CustomButtonRenderer))]

namespace bots.Droid
{
	
	public class Data
	{
		public String name;
		public List<Problems> problems;
		public List<Paragraphs> paragraphs;
	}
	public class Problems
	{
		public String tag;
		public String msg;
		public String weight;

	}

	public class Paragraphs
	{
		public String text;
		public String weight;
	}

	public class CustomButtonRenderer : ButtonRenderer
	{
		private static string autoType;
		public CustomButtonRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			Control.SetPadding(0, 10, 0, 10);
			//Control.Click += (object sender, EventArgs es) => getData("");
		}



	}
}
