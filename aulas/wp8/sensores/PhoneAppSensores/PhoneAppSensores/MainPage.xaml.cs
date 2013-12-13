using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Devices.Sensors;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework;
using PhoneAppSensores.Resources;

namespace PhoneAppSensores
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            Accelerometer accelerometer = new Accelerometer();
            accelerometer.TimeBetweenUpdates = TimeSpan.FromMilliseconds(20);
            accelerometer.CurrentValueChanged +=
                new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(LeituraAcelerometro);
            accelerometer.Start();
        }

        private void Click_Acelerometro(object sender, RoutedEventArgs e)
        {
            
            

        }

        void LeituraAcelerometro(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            Vector3 acceleration = e.SensorReading.Acceleration;
            Dispatcher.BeginInvoke(() => {
                string x = acceleration.X.ToString("f");
                string y = acceleration.Y.ToString("f");
                string z = acceleration.Z.ToString("f");
         
                tb.Text = x +" " + y  + " "+ z;
            });
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}