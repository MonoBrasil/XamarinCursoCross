using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Webkit;

// Dia 1 - Exemplo 7 WebView - http://docs.xamarin.com/guides/android/user_interface/web_view

namespace Dia1Ex7
{
	[Activity (Label = "Dia1-Ex7", MainLauncher = true)]
	public class MainActivity : Activity
	{
		WebView web_view;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Coloca o layout "main" dos recursos em nossa view
			SetContentView (Resource.Layout.Main);

			web_view = FindViewById<WebView> (Resource.Id.webview);
			web_view.Settings.JavaScriptEnabled = true;
			web_view.LoadUrl ("http://www.google.com");
		}
	}
}


