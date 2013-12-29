using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

// Dia 1 - Exemplo 6 List View - http://docs.xamarin.com/guides/android/user_interface/working_with_listviews_and_adapters

namespace Dia1Ex6
{
	[Activity (Label = "Dia1-Ex6", MainLauncher = true)]
	public class MainActivity: ListActivity 
	{
		string[] items;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			items = new string[] { "Vegetais","Frutas","Flores","Legumes","Bulbos","Tubérculos" };
			ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
		}

		protected override void OnListItemClick(ListView l, View v, int position, long id)
		{
			var t = items[position];
			Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();

		}
	}
}


