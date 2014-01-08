using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Dia1Ex16
{
	[Activity (Label = "Dia1-Ex16", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Coloca o layout "main" dos recursos em nossa view
			SetContentView (Resource.Layout.Main);

			// Pega o botão do recurso de layout e coloca um evento nele
			Button segunda_tela = FindViewById<Button> (Resource.Id.segunda_tela);
			
			segunda_tela.Click += delegate {
				StartActivity(typeof(SecondActivity));
			};

			Button terceira_tela = FindViewById<Button> (Resource.Id.terceira_tela);

			terceira_tela.Click += delegate {
				var third = new Intent(this, typeof(ThirdActivity));

				third.PutExtra("Dado1", "Informação passada como parâmetro pela MainActivity");

				StartActivity(third);

			};
		}
	}
}


