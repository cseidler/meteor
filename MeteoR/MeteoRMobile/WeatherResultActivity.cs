using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MeteoRInterfaceModel;
using Newtonsoft.Json;

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
        private int stationId;

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

            stationId = int.Parse(Intent.Extras.Get("stationId").ToString());
            service = new MeteorServiceClient();

            this.CallService();
        }

        private async void CallService()
        {
            try
            {
                if (stationId == 0)
                {
                   weatherInfo = await this.service.GetWeatherInfo(stationId, new DateTimeToUnixConverter().DateTimeToUnixTimeStamp(DateTime.Now));
                }

                if (stationId == 71)
                {
                    var ServiceUri = "http://192.168.1.71:8080/meteorit/REST/measurement/14";

                    weatherInfo = CallServiceAndDeserializeObject(ServiceUri);
                }

                if (stationId == 54)
                {
                    var ServiceUri = "http://192.168.1.54:8088/CurrentWeather/54";

                    weatherInfo = CallServiceAndDeserializeObject(ServiceUri);
                }

                if (stationId == 10)
                {
                    var ServiceUri = "http://192.168.1.10:8088/weatherrecord/14";

                    weatherInfo = CallServiceAndDeserializeObject(ServiceUri);
                }

                RunOnUiThread(() =>
                {
                    stationIdData.Text = stationId.ToString(CultureInfo.InvariantCulture);
                    cityNameData.Text = weatherInfo.CityName;
                    timestampData.Text = weatherInfo.Timestamp.ToString(CultureInfo.InvariantCulture);
                    temperatureData.Text = weatherInfo.Temperature.ToString(CultureInfo.InvariantCulture);
                    pressureData.Text = weatherInfo.Pressure.ToString(CultureInfo.InvariantCulture);
                    humidityData.Text = weatherInfo.Humidity.ToString(CultureInfo.InvariantCulture);
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine(string.Format("Exception message: {0}", exception.Message));
            }
        }

        private static WeatherInfo CallServiceAndDeserializeObject(string ServiceUri)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(ServiceUri).Result;
                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;

                var info = JsonConvert.DeserializeObject<WeatherInfo>(content);

                return info;
            }
        }
    }
}