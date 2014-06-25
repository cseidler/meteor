using System;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.Widget;
using Android.OS;
using MeteoRInterfaceModel;

namespace MeteoRMobile
{
    [Activity(Label = "MeteoRMobile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button receiveDataButton;
        private TextView stationIdInput;
        private Button weatherStation71;
        private Button weatherStation10;
        private Button weatherStation54;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            stationIdInput = FindViewById<TextView>(Resource.Id.stationIdInput);
            receiveDataButton = FindViewById<Button>(Resource.Id.receiveData);

            weatherStation10 = FindViewById<Button>(Resource.Id.weatherStation10);
            weatherStation54 = FindViewById<Button>(Resource.Id.weatherStation54);
            weatherStation71 = FindViewById<Button>(Resource.Id.weatherStation71);

            // Get our button from the layout resource,
            // and attach an event to it
            receiveDataButton.Click += ReceiveDataButtonOnClick;
            weatherStation10.Click += ReceiveWeatherStation10DataButtonOnClick;
            weatherStation54.Click += ReceiveWeatherStation54DataButtonOnClick;
            weatherStation71.Click += ReceiveWeatherStation71DataButtonOnClick;
        }

        private void ReceiveWeatherStation10DataButtonOnClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(WeatherResultActivity));
            intent.PutExtra("stationId", 10);
            StartActivity(intent);
        }

        private void ReceiveWeatherStation54DataButtonOnClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(WeatherResultActivity));
            intent.PutExtra("stationId", 54);
            StartActivity(intent);
        }

        private void ReceiveWeatherStation71DataButtonOnClick(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(WeatherResultActivity));
            intent.PutExtra("stationId", 71);
            StartActivity(intent);
        }

        private async void ReceiveDataButtonOnClick(object sender, EventArgs eventArgs)
        {
            var stationId = int.Parse(stationIdInput.Text);

            var intent = new Intent(this, typeof(WeatherResultActivity));
            intent.PutExtra("stationId", stationId);
            StartActivity(intent);
        }
    }
}

