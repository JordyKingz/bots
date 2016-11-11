using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
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
			getSnippet();
			Console.WriteLine("incoming");

			if (Control.Text == "Verzenden")
			{
				
			}

		}

		public async Task postSnippet()
		{
			
		}





		public async Task getSnippet()
		{

			try
			{
				var guid = 0;
				var client = new HttpClient();
				var content = new FormUrlEncodedContent(new[]
			{
					new KeyValuePair<string, string>("guid",guid.ToString() )
			});
				//var content = input; csharp-legal-text-check
				var result = await client.PostAsync("http://peterschriever.com/api/v1/get-snippet", content).ConfigureAwait(false);

				if (result.IsSuccessStatusCode)
				{
					var data = await result.Content.ReadAsStringAsync();

					App.Snippet snip = JsonConvert.DeserializeObject<App.Snippet>(data);


					//List<bots.App.Data> gegevens = JsonConvert.DeserializeObject<List<bots.App.Data>>(data);
					App.snip = snip;


					//App.dat = gegevens;


				}



			}
			catch (Exception e)
			{
				//Console.WriteLine("Geen juist kenteken");


			}
		}



	}
}
