using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Dia1Ex5
{
	[Activity]
	public class WhatsOnActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			TextView textview = new TextView (this);
			textview.Text = "This is the My What's On tab";
			SetContentView (textview);
		}
	}
}

