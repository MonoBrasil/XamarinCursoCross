using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Reflection;

namespace Dia1Ex15
{
	[Activity (Label = "Dia1-Ex15", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Coloca o layout "main" dos recursos em nossa view
			SetContentView (Resource.Layout.Main);

			TextView state = FindViewById<TextView> (Resource.Id.state);

			var prefs = this.GetSharedPreferences("Arquivo de Config",
				FileCreationMode.Private);

			var editor = prefs.Edit();

			if (prefs.Contains ("PrimeiraExecucao")) {
				int execucoes = prefs.GetInt ("Execucoes", 1);
				execucoes++;
				editor.PutInt("Execucoes", execucoes);
				Version version = Assembly.GetExecutingAssembly ().GetName ().Version;
				Version old_version = new Version(prefs.GetString ("Versao", "0.0.0.1"));

				if (version > old_version) {
					editor.PutString ("Versao", version.ToString ());
					state.Text = "Estado do Aplicativo: Upgrade (execução " + execucoes + ")";
				} else if (version < old_version) {
					editor.PutString ("Versao", version.ToString ());
					state.Text = "Estado do Aplicativo: Downgrade (execução " + execucoes + ")" ;
				} else {
					state.Text = "Estado do Aplicativo: Execução normal " + execucoes;
				}
			} else {
				editor.PutString("PrimeiraExecucao", "OK");
				editor.PutInt("Execucoes", 1);
				Version version = Assembly.GetExecutingAssembly ().GetName ().Version;
				editor.PutString("Versao",  version.ToString());
				state.Text = "Estado do Aplicativo: Primeira execução";
			}

			editor.Commit();
		}
	}
}


