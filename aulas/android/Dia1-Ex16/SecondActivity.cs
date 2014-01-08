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
	[Activity (Label = "SecondActivity")]			
	public class SecondActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Coloca o layout "main" dos recursos em nossa view
			SetContentView (Resource.Layout.Second);

			// Pega o botão do recurso de layout e coloca um evento nele
			Button terceira_tela = FindViewById<Button> (Resource.Id.terceira_tela);

			terceira_tela.Click += delegate {
				var third = new Intent(this, typeof(ThirdActivity));

				third.PutExtra("Dado1", "Informação passada como parâmetro pela SecondActivity");

				StartActivity(third);

			};
		}
	}
}

