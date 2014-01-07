using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Contacts;
using System.Linq;
using Android.Telephony;
using System.Threading.Tasks;

namespace Dia1Ex12
{
	[Activity (Label = "Dia1-Ex12", MainLauncher = true)]
	public class MainActivity : Activity
	{
		const int ligacao_agenda = 0x5a;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Coloca o layout "main" dos recursos em nossa view
			SetContentView (Resource.Layout.Main);

			// Pega o botão do recurso de layout e coloca um evento nele
			Button envia_email = FindViewById<Button> (Resource.Id.envia_email);

			envia_email.Click += delegate {
				var email = new Intent (Android.Content.Intent.ActionSend);
				email.PutExtra (Android.Content.Intent.ExtraEmail, 
					new string[]{ "alexandre@monobrasil.com.br", "binhara@monobrasil.com.br" });
				email.PutExtra (Android.Content.Intent.ExtraCc, new string[]{ "alexandre.marcondes@gmail.com" });
				email.PutExtra (Android.Content.Intent.ExtraSubject, "Olá Android - Email");
				email.PutExtra (Android.Content.Intent.ExtraText, "Olá por Xamarin.Android");	
				email.SetType ("message/rfc822");
				StartActivity (email);
			};

			Button envia_sms = FindViewById<Button> (Resource.Id.envia_sms);

			envia_sms.Click += delegate {
				SmsManager.Default.SendTextMessage ("1234567890", null,
					"Olá do Xamarin.Android", null, null);	
					
				var smsUri = Android.Net.Uri.Parse ("smsto:1234567890");
				var smsIntent = new Intent (Intent.ActionSendto, smsUri);
				smsIntent.PutExtra ("sms_body", "Olá do Xamarin.Android");  
				StartActivity (smsIntent);
			};

			Button faz_ligacao_direta = FindViewById<Button> (Resource.Id.faz_ligacao_direta);

			faz_ligacao_direta.Click += delegate {
				var uri = Android.Net.Uri.Parse ("tel:1112223333");
				var intent = new Intent (Intent.ActionView, uri); 
				StartActivity (intent);     
			};

			Button faz_ligacao_agenda = FindViewById<Button> (Resource.Id.faz_ligacao_agenda);

			faz_ligacao_agenda.Click += delegate {
				var contactPickerIntent = new Intent (Intent.ActionPick,
					                          Android.Provider.ContactsContract.Contacts.ContentUri);

				StartActivityForResult (contactPickerIntent, ligacao_agenda);
			};
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			if (requestCode == ligacao_agenda && resultCode == Result.Ok) {
				if (data == null || data.Data == null)
					return;

				var addressBook = new AddressBook (this);
				addressBook.PreferContactAggregation = true;

				var pathSegments = data.Data.PathSegments;
				var contact = addressBook.Load (pathSegments[pathSegments.Count - 1]);
				if (contact == null)
					contact = addressBook.Load (pathSegments[pathSegments.Count - 2]);
				if (contact == null)
					return;

				var mobile = (from p in contact.Phones
				               where p.Type == Xamarin.Contacts.PhoneType.Mobile
				               select p.Number).FirstOrDefault ();

				if (string.IsNullOrEmpty (mobile))
					return;

				var uri = Android.Net.Uri.Parse (string.Format ("tel:{0}", mobile));
				var intent = new Intent (Intent.ActionView, uri); 

				StartActivity (intent);
			}
		}
	}
}
