using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Text;

namespace Dia1Ex9
{
	[Activity (Label = "Dia1-Ex9", MainLauncher = true)]
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
				TextView tv_password = FindViewById<TextView> (Resource.Id.text_view_password);
				TextView tv_radio_button = FindViewById<TextView> (Resource.Id.text_view_radio_button);
				TextView tv_check_box = FindViewById<TextView> (Resource.Id.text_view_check_box);
				TextView tv_seek_bar = FindViewById<TextView> (Resource.Id.text_view_seek_bar);

				EditText et_password = FindViewById<EditText> (Resource.Id.edit_text_password);
				RadioButton rb_1 = FindViewById<RadioButton> (Resource.Id.radio_button_1);
				RadioButton rb_2 = FindViewById<RadioButton> (Resource.Id.radio_button_2);
				RadioButton rb_3 = FindViewById<RadioButton> (Resource.Id.radio_button_3);
				CheckBox cb_1 = FindViewById<CheckBox> (Resource.Id.check_box_1);
				CheckBox cb_2 = FindViewById<CheckBox> (Resource.Id.check_box_2);
				CheckBox cb_3 = FindViewById<CheckBox> (Resource.Id.check_box_3);
				SeekBar seek_bar = FindViewById<SeekBar> (Resource.Id.seek_bar);

				tv_password.Text = String.Format("A senha é \"{0}\"", et_password.Text);

				if (rb_1.Checked)
					tv_radio_button.Text = rb_1.Text;
				if (rb_2.Checked)
					tv_radio_button.Text = rb_2.Text;
				if (rb_3.Checked)
					tv_radio_button.Text = rb_3.Text;

				StringBuilder sb = new StringBuilder("A seleção é \"");
				if (cb_1.Checked)
					sb.AppendFormat("{0},", cb_1.Text);
				if (cb_2.Checked)
					sb.AppendFormat("{0},", cb_2.Text);
				if (cb_3.Checked)
					sb.AppendFormat("{0},", cb_3.Text);
				sb.Remove(sb.Length - 1, 1);
				tv_check_box.Text = sb.ToString();
				sb.Append("\"");

				tv_seek_bar.Text = String.Format("O valor da seek bar é {0}", seek_bar.Progress);
			};
		}
	}
}


