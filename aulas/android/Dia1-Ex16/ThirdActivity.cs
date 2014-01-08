using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Dia1Ex16
{
	[Activity (Label = "ThirdActivity")]			
	public class ThirdActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Coloca o layout "main" dos recursos em nossa view
			SetContentView (Resource.Layout.Third);

			TextView mensagem = FindViewById<TextView> (Resource.Id.message);

			Bundle b = Intent.Extras;
			mensagem.Text = b.GetString("Dado1");
		}
	}
}

