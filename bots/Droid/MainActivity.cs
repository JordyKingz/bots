using System;
using Android.App;
using Android.Graphics.Drawables;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Graphics;
using Android.Content;
using Android.Util;
using System.Threading.Tasks;
using Android.Media;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices;
using Android.Content.PM;
using System.Threading;

namespace bots.Droid
{
	[Activity(Label = "Valitos", Icon = "@drawable/logo", Theme = "@style/MyTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		
		protected override void OnCreate(Bundle bundle)
		{



			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			//SetContentView(Resource.Layout.Main);
			//
			//SetContentView(Resource.Layout.Main);

			//animate = FindViewById<AnimationView>(Resource.Id.imgAnimate);


			//Animate();
			//

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());

		}






	}

}
