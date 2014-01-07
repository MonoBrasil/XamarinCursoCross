using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;
using System.Text;
using Android.Locations;
using System.Collections.Generic;
using System.Linq;

namespace Dia1Ex13
{
	[Activity (Label = "Dia1-Ex13", MainLauncher = true)]
	public class MainActivity : Activity, ISensorEventListener, ILocationListener
	{
		SensorManager sensorManager;
		Location currentLocation;
		LocationManager locationManager;
		static readonly object sensorSyncLock = new object ();
		string locationProvider;
		TextView usa_acelerometro;
		TextView gps_coordinates;
		TextView gps_location;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Coloca o layout "main" dos recursos em nossa view
			SetContentView (Resource.Layout.Main);

			// Pega o botão do recurso de layout e coloca um evento nele
			Button usa_gps = FindViewById<Button> (Resource.Id.usa_gps);
			usa_acelerometro = FindViewById<TextView> (Resource.Id.usa_acelerometro);
			gps_coordinates = FindViewById<TextView> (Resource.Id.gps_coordinates);
			gps_location = FindViewById<TextView> (Resource.Id.gps_location);

			sensorManager = (SensorManager)GetSystemService (Context.SensorService);
			InitializeLocationManager ();	

			usa_gps.Click += async delegate {
				if (currentLocation == null)
					return;

				Geocoder geocoder = new Geocoder (this);
				IList<Address> addressList = await geocoder.GetFromLocationAsync (
					                             currentLocation.Latitude, currentLocation.Longitude, 10);
				Address address = addressList.FirstOrDefault ();
				if (address != null) {
					StringBuilder deviceAddress = new StringBuilder ();
					for (int i = 0; i < address.MaxAddressLineIndex; i++) {
						deviceAddress.Append (address.GetAddressLine (i)).AppendLine (",");
					}

					gps_location.Text = deviceAddress.ToString ();
				} else {
					gps_location.Text = "Não foi possível localizar esta posição";
				}

			};
		}

		public void OnAccuracyChanged (Sensor sensor, SensorStatus accuracy)
		{
		}

		public void OnSensorChanged (SensorEvent e)
		{
			lock (sensorSyncLock) {
				var text = new StringBuilder ("Acelerometro: x = ")
					.Append (e.Values [0])
					.Append (", y=")
					.Append (e.Values [1])
					.Append (", z=")
					.Append (e.Values [2]);
				usa_acelerometro.Text = text.ToString ();
			}
		}

		public void OnLocationChanged (Location location)
		{
			currentLocation = location;
			if (currentLocation == null) {
				Toast.MakeText (this, "Unable to determine your location.", ToastLength.Short);
			} else {
				gps_coordinates.Text = String.Format ("{0},{1}",
					currentLocation.Latitude, currentLocation.Longitude);
			}
		}

		protected override void OnResume ()
		{
			base.OnResume ();
			sensorManager.RegisterListener (this, sensorManager.GetDefaultSensor (
				SensorType.Accelerometer), SensorDelay.Ui);
			locationManager.RequestLocationUpdates (locationProvider, 0, 0, this);
		}

		protected override void OnPause ()
		{
			base.OnPause ();
			sensorManager.UnregisterListener (this);
			locationManager.RemoveUpdates (this);
		}

		public void OnProviderDisabled (string provider)
		{
		}

		public void OnProviderEnabled (string provider)
		{
		}

		public void OnStatusChanged (string provider, Availability status, Bundle extras)
		{
		}

		void InitializeLocationManager ()
		{
			locationManager = (LocationManager)GetSystemService (LocationService);
			Criteria criteriaForLocationService = new Criteria {
				Accuracy = Accuracy.Fine
			};
			IList<string> acceptableLocationProviders =
				locationManager.GetProviders (criteriaForLocationService, true);

			if (acceptableLocationProviders.Any ()) {
				locationProvider = acceptableLocationProviders.First ();
			} else {
				locationProvider = String.Empty;
			}
				
			locationManager.RequestLocationUpdates (locationProvider, 0, 0, this);
		}
	}
}


