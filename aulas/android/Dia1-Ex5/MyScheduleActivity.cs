using System;
using Android.App;
using Android.Widget;
using Android.OS;

namespace Dia1Ex5
{
	[Activity]
	public class MyScheduleActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			TextView textview = new TextView (this);
			textview.Text = "This is the My Schedule tab";
			SetContentView (textview);
		}
	}
}

