using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using com.refractored.monodroidtoolkit;
using CrossPieCharts.FormsPlugin.Abstractions;
using CrossPieCharts.FormsPlugin.Android;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CrossPieChartView), typeof(CrossPieChartRenderer))]

namespace CrossPieCharts.FormsPlugin.Android
{
    /// <summary>
    /// CrossPieChart Renderer
    /// </summary>
    public class CrossPieChartRenderer : ViewRenderer<CrossPieChartView, HoloCircularProgressBar>
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CrossPieChartView> e)
        {

            base.OnElementChanged(e);

            var progressBar = Element as CrossPieChartView;

			if (bots.App.review <3)
			{
				PostSnippet();
			}


            if (e.OldElement != null || progressBar == null)
            {
                return;
            }

            var progress = new HoloCircularProgressBar(Forms.Context)
            {

                Progress = progressBar.Progress,
                ProgressColor = progressBar.ProgressColor.ToAndroid(),
                ProgressBackgroundColor = progressBar.ProgressBackgroundColor.ToAndroid(),
                CircleStrokeWidth = progressBar.StrokeThickness,
            };

            //var display = Resources.DisplayMetrics;

            progressBar.HeightRequest = progressBar.Radius * 2;
            progressBar.WidthRequest = progressBar.Radius * 2;

            SetNativeControl(progress);
        }



		public async Task PostSnippet()
		{

			try
			{
				var guid = 0;
				var snippetId = bots.App.snip.snippetId;
				var review = bots.App.review;
				var reviewComment = bots.App.reviewComment;
				var client = new HttpClient();
				var content = new FormUrlEncodedContent(new[]
			{
					new KeyValuePair<string, string>("guid",guid.ToString()),
					new KeyValuePair<string, string>("snippertId",snippetId.ToString()),
					new KeyValuePair<string, string>("review",review.ToString()),
					new KeyValuePair<string, string>("reviewComment",reviewComment)
			});
				//var content = input; csharp-legal-text-check
				var result = await client.PostAsync("http://peterschriever.com/api/v1/store-snippet", content).ConfigureAwait(false);

				if (result.IsSuccessStatusCode)
				{
					var data = await result.Content.ReadAsStringAsync();
					System.Diagnostics.Debug.WriteLine(data);
					bots.App.review = 3;


					//List<bots.App.Data> gegevens = JsonConvert.DeserializeObject<List<bots.App.Data>>(data);
					//bots.App.snip = snip;


					//App.dat = gegevens;


				}



			}
			catch (Exception e)
			{
				//Console.WriteLine("Geen juist kenteken");


			}
		}



        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            if (e.PropertyName == CrossPieChartView.ProgressProperty.PropertyName)
            {
                Control.Progress = Element.Progress;
            }
            else if (e.PropertyName == CrossPieChartView.ProgressBackgroundColorProperty.PropertyName)
            {
                Control.ProgressBackgroundColor = Element.ProgressBackgroundColor.ToAndroid();
            }
            else if (e.PropertyName == CrossPieChartView.ProgressColorProperty.PropertyName)
            {
                Control.ProgressColor = Element.ProgressColor.ToAndroid();
            }
            else if (e.PropertyName == CrossPieChartView.StrokeThicknessProperty.PropertyName)
            {
                Control.IndeterminateInterval = Element.StrokeThickness;
            }
            else if (e.PropertyName == CrossPieChartView.RadiusProperty.PropertyName)
            {
                Control.IndeterminateInterval = Element.Radius;
            }
        }
    }
}