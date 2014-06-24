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
        private MeteorServiceClient service;
        private Button receiveDataButton;
        private TextView humidityData;
        private TextView cityNameData;
        private TextView stationIdData;
        private TextView timestampData;
        private TextView temperaturedata;
        private TextView pressureData;
        private TextView stationIdInput;
        private WeatherInfo weatherData;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            stationIdInput = FindViewById<TextView>(Resource.Id.stationIdInput);
            receiveDataButton = FindViewById<Button>(Resource.Id.receiveData);

            // Data fields
            stationIdData = FindViewById<TextView>(Resource.Id.stationIdData);
            cityNameData = FindViewById<TextView>(Resource.Id.cityNameData);
            timestampData = FindViewById<TextView>(Resource.Id.timestampData);
            temperaturedata = FindViewById<TextView>(Resource.Id.temperatureData);
            pressureData = FindViewById<TextView>(Resource.Id.pressureData);
            humidityData = FindViewById<TextView>(Resource.Id.humidityData);

            service = new MeteorServiceClient();

            // Get our button from the layout resource,
            // and attach an event to it
            receiveDataButton.Click += ReceiveDataButtonOnClick;  
            
        }

        private async void ReceiveDataButtonOnClick(object sender, EventArgs eventArgs)
        {
            //var stationId = int.Parse(stationIdInput.Text);

            try
            {
                weatherData = await this.service.GetWeatherInfo(123, 456);
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("Exception message: {0}", exception.Message));
            }

            RunOnUiThread(() => { });

            var intent = new Intent(this, typeof(WeatherResultActivity));

            StartActivity(intent);

            /*
            stationIdData = weatherData.Id;
            cityNameData = weatherData.CityName;
            timestampData = weatherData.Timestamp;
            temperaturedata = weatherData.Temperature;
            pressureData = weatherData.Pressure;
            humidityData = weatherData.Humidity;
            */

            cityNameData.Text = "Moskau";
            humidityData.Text = "10";
        }
    }
}

