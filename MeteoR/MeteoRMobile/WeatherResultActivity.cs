using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MeteoRMobile
{
    [Activity(Label = "WeatherResult")]
    public class WeatherResultActivity : Activity
    {
        private TextView humidityData;
        private TextView cityNameData;
        private TextView stationIdData;
        private TextView timestampData;
        private TextView temperaturedata;
        private TextView pressureData;
        private TextView stationIdInput;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            stationIdData = FindViewById<TextView>(Resource.Id.stationIdData);
            cityNameData = FindViewById<TextView>(Resource.Id.cityNameData);
            timestampData = FindViewById<TextView>(Resource.Id.timestampData);
            temperaturedata = FindViewById<TextView>(Resource.Id.temperatureData);
            pressureData = FindViewById<TextView>(Resource.Id.pressureData);
            humidityData = FindViewById<TextView>(Resource.Id.humidityData);

            var weatherData = Intent.Data;
        }
    }
}