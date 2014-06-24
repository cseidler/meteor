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
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            stationIdInput = FindViewById<TextView>(Resource.Id.stationIdInput);
            receiveDataButton = FindViewById<Button>(Resource.Id.receiveData);

            // Get our button from the layout resource,
            // and attach an event to it
            receiveDataButton.Click += ReceiveDataButtonOnClick;  
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

