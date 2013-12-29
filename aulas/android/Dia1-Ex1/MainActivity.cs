using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

// Dia 1 - Exemplo 1 Linear Layout - http://docs.xamarin.com/guides/android/user_interface/linear_layout/

namespace Dia1Ex1
{
	[Activity (Label = "Dia1-Ex1", MainLauncher = true)]
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


