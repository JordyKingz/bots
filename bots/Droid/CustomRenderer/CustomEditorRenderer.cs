using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using bots;
using bots.Droid;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(CustomEditor),typeof(CustomEditorRenderer))]
namespace bots.Droid
{
	public class CustomEditorRenderer : EditorRenderer
	{
		public CustomEditorRenderer()
		{
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			getDataFromTekst(Control.Text);

		}

		public async Task getDataFromTekst(string input)
		{

			try
			{




				var client = new HttpClient();
				var content = new FormUrlEncodedContent(new[]
			{
					new KeyValuePair<string, string>("text", input)
			});
				//var content = input; csharp-legal-text-check
				var result = await client.PostAsync("http://peterschriever.com/api/v1/csharp-legal-text-check-paste", content).ConfigureAwait(false);

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
