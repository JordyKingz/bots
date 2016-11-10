using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using bots;
using bots.iOS;
using Newtonsoft.Json;
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