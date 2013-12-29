using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

// Dia 1 - Exemplo 3 Table Layout - http://docs.xamarin.com/guides/android/user_interface/table_layout

namespace Dia1Ex3
{
	[Activity (Label = "Dia1-Ex3", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Coloca o layout "main" dos recursos em nossa view
			SetContentView (Resource.Layout.Main);
		}
	}
}


