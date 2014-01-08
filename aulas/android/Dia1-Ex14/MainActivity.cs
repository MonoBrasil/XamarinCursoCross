using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Net;
using Android.Telephony;

namespace Dia1Ex14
{
	[Activity (Label = "Dia1-Ex14", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Coloca o layout "main" dos recursos em nossa view
			SetContentView (Resource.Layout.Main);

			TextView conectividade = FindViewById<TextView> (Resource.Id.conectividade);

			var connectivityManager = (ConnectivityManager)GetSystemService (
				                          ConnectivityService);

			var activeConnection = connectivityManager.ActiveNetworkInfo;
			if ((activeConnection != null) && activeConnection.IsConnected) {
				conectividade.Text = "Conectividade: Estamos conectados";
			} else {
				conectividade.Text = "Conectividade: Não estamos conectados";
			}

			var mobileState = connectivityManager.GetNetworkInfo (
				                  ConnectivityType.Mobile).GetState ();
			if (mobileState == NetworkInfo.State.Connected) {
				conectividade.Text += " (com WiFi)";
			}

			if (UpdateNetworkStatus() == NetworkState.ConnectedData)
			{
				conectividade.Text += " (com dados)";
			}

			TextView phone_id = FindViewById<TextView> (Resource.Id.phone_id);

			TelephonyManager tManager = (TelephonyManager)this.GetSystemService(Context.TelephonyService);
			phone_id.Text = string.Format("ID do AParelho: {0}", tManager.DeviceId);
		}

		public NetworkState UpdateNetworkStatus ()
		{
			var _state = NetworkState.Unknown;
			 
			var connectivityManager = (ConnectivityManager)
				Application.Context.GetSystemService (Context.ConnectivityService);
			 
			var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
			 
			if (activeNetworkInfo.IsConnectedOrConnecting) {
				_state = activeNetworkInfo.Type == ConnectivityType.Wifi ?
					                NetworkState.ConnectedWifi : NetworkState.ConnectedData;
			} else {
				_state = NetworkState.Disconnected;
			}
		  
			return _state;
		}

		public enum NetworkState
		{
			Unknown,
			ConnectedWifi,
			ConnectedData,
			Disconnected
		}
	}
}


