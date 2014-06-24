using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MeteoRInterfaceModel;

namespace MeteoRMobile
{
    [Activity(Label = "WeatherResult")]
    public class WeatherResultActivity : Activity
    {
        private TextView humidityData;
        private TextView cityNameData;
        private TextView stationIdData;
        private TextView timestampData;
        private TextView temperatureData;
        private TextView pressureData;
        private TextView stationIdInput;
        private MeteorServiceClient service;
        private WeatherInfo weatherInfo;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.WeatherResult);
            // Create your application here
            stationIdData = FindViewById<TextView>(Resource.Id.stationIdData);
            cityNameData = FindViewById<TextView>(Resource.Id.cityNameData);
            timestampData = FindViewById<TextView>(Resource.Id.timestampData);
            temperatureData = FindViewById<TextView>(Resource.Id.temperatureData);
            pressureData = FindViewById<TextView>(Resource.Id.pressureData);
            humidityData = FindViewById<TextView>(Resource.Id.humidityData);

            var stationId = Intent.Extras.Get("stationId").ToString();
            service = new MeteorServiceClient();

            this.CallService();
        }

        private async void CallService()
        {
            try
            {
                weatherInfo = await this.service.GetWeatherInfo(123, 456);
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("Exception message: {0}", exception.Message));
            }
            RunOnUiThread(() => { });

            stationIdData.Text = "1";
            cityNameData.Text = "Moskau";
            timestampData.Text = DateTime.Now.ToShortDateString().ToString(CultureInfo.InvariantCulture);
            temperatureData.Text = "18";
            pressureData.Text = "886";
            humidityData.Text = "20";


            stationIdData.Text = weatherInfo.Id.ToString(CultureInfo.InvariantCulture);
            cityNameData.Text = weatherInfo.CityName;
            timestampData.Text = weatherInfo.Timestamp.ToString(CultureInfo.InvariantCulture);
            temperatureData.Text = weatherInfo.Temperature.ToString(CultureInfo.InvariantCulture);
            pressureData.Text = weatherInfo.Pressure.ToString(CultureInfo.InvariantCulture);
            humidityData.Text = weatherInfo.Humidity.ToString(CultureInfo.InvariantCulture);
            
        }
    }
}