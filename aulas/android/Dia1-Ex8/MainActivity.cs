using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Dia1Ex8
{
	[Activity (Label = "Dia1-Ex8", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Carega o layout "main" na view principal
			SetContentView (Resource.Layout.Main);

			// Pega o botão do recurso de layout e coloca um evento nele
			Button button = FindViewById<Button> (Resource.Id.button);
			
			button.Click += delegate {
				EditText et_number = FindViewById<EditText> (Resource.Id.edit_text_number);
				EditText et_phone = FindViewById<EditText> (Resource.Id.edit_text_phone);
				EditText et_address = FindViewById<EditText> (Resource.Id.edit_text_address);
				EditText et_email = FindViewById<EditText> (Resource.Id.edit_text_email);

				TextView tv_large = FindViewById<TextView> (Resource.Id.text_view_large);
				TextView tv_medium = FindViewById<TextView> (Resource.Id.text_view_medium);
				TextView tv_small = FindViewById<TextView> (Resource.Id.text_view_small);
				TextView tv_simple = FindViewById<TextView> (Resource.Id.text_view);

				ImageView iv_simple = FindViewById<ImageView> (Resource.Id.image_view);

				tv_large.Text = et_number.Text;
				tv_medium.Text = et_phone.Text;
				tv_small.Text = et_address.Text;
				tv_simple.Text = et_email.Text;

				iv_simple.SetImageResource(Resource.Drawable.xamarin);
			};
		}
	}

}


