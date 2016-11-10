using System;
using bots;
using bots.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


[assembly: ExportRenderer(typeof(SearchEntry), typeof(SearchEntryRenderer))]
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

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			getData(Control.Text);

		}

		public async Task getData(string input)
		{

			try
			{




				var client = new HttpClient();
				var content = new FormUrlEncodedContent(new[]
			{
					new KeyValuePair<string, string>("url", input)
			});
				//var content = input; csharp-legal-text-check
				var result = await client.PostAsync("http://peterschriever.com/api/v1/csharp-legal-text-check", content).ConfigureAwait(false);

				if (result.IsSuccessStatusCode)
				{
					var data = await result.Content.ReadAsStringAsync();
					Console.WriteLine(data);



					List<bots.App.Data> gegevens = JsonConvert.DeserializeObject<List<bots.App.Data>>(data);



					App.dat = gegevens;


				}



			}
			catch (Exception e)
			{
				//Console.WriteLine("Geen juist kenteken");


			}
		}

	}
}
