using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Provider;
using System.Collections.Generic;
using Android.Database;
using Android.Content.PM;
using Java.IO;

namespace Dia1Ex11
{
	[Activity (Label = "Dia1-Ex11", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int selecionaImagem = 0x5a;
		int pegaCamera = 0x5b;

		ImageView image_view;
		ListView contacts;
		File _dir;

		File _file;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Coloca o layout "main" dos recursos em nossa view
			SetContentView (Resource.Layout.Main);

			image_view = FindViewById<ImageView> (Resource.Id.image_view);
			contacts = FindViewById<ListView> (Resource.Id.contacts);

			// Pega o botão do recurso de layout e coloca um evento nele
			Button import_contacts = FindViewById<Button> (Resource.Id.import_contacts);
			
			import_contacts.Click += delegate {
				contacts.Visibility = ViewStates.Visible;
				image_view.Visibility = ViewStates.Invisible;
				contacts.Adapter = new ContactsAdapter(this);
			};

			Button import_picture = FindViewById<Button> (Resource.Id.import_picture);

			import_picture.Click += delegate {
				Intent = new Intent();
				Intent.SetType("image/*");
				Intent.SetAction(Intent.ActionGetContent);
				StartActivityForResult(Intent.CreateChooser(Intent, "Escolha a Imagem"), selecionaImagem);

			};

			Button import_camera = FindViewById<Button> (Resource.Id.import_camera);

			import_camera.Click += delegate {
				Intent intent = new Intent(MediaStore.ActionImageCapture);

				_file = new File (_dir, String.Format ("myPhoto_{0}.jpg", Guid.NewGuid ()));

				intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(_file));

				StartActivityForResult(intent, 0);
			};
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			if ((requestCode == selecionaImagem) && (resultCode == Result.Ok) && 
				(data != null))
			{
				Android.Net.Uri uri = data.Data;

				image_view.SetImageURI(uri);
				image_view.Visibility = ViewStates.Visible;
				contacts.Visibility = ViewStates.Invisible;

				string path = GetPathToImage(uri);
				Toast.MakeText(this, path, ToastLength.Long);
			}

			if (requestCode == pegaCamera) {
				Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
				Android.Net.Uri contentUri = Android.Net.Uri.FromFile(_file);
				mediaScanIntent.SetData(contentUri);
				SendBroadcast(mediaScanIntent);
			}
		}

		private string GetPathToImage(Android.Net.Uri uri)
		{
			string path = null;

			string[] data = new[] { 
				Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data };

			using (ICursor cursor = ManagedQuery(uri, data, null, null, null))
			{
				if (cursor != null)
				{
					int columnIndex = cursor.GetColumnIndexOrThrow(
						Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data);
					cursor.MoveToFirst();
					path = cursor.GetString(columnIndex);
				}
			}
			return path;
		}	

		private bool IsThereAnAppToTakePictures()
		{
			Intent intent = new Intent(MediaStore.ActionImageCapture);

			IList<ResolveInfo> availableActivities = PackageManager.
				QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);

			return availableActivities != null && availableActivities.Count > 0;
		}

		private void CreateDirectoryForPictures()
		{
			_dir = new File (
				Android.OS.Environment.GetExternalStoragePublicDirectory (
					Android.OS.Environment.DirectoryPictures), "CameraAppDemo");

			if (!_dir.Exists())
			{
				_dir.Mkdirs();
			}
		}	
	}
}


