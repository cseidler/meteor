using System;
using Android.App;
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

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            receiveDataButton = FindViewById<Button>(Resource.Id.receiveData);

            humidityData = FindViewById<TextView>(Resource.Id.humidityData);
            cityNameData = FindViewById<TextView>(Resource.Id.cityNameData);

            service = new MeteorServiceClient();

            // Get our button from the layout resource,
            // and attach an event to it
            receiveDataButton.Click += ReceiveDataButtonOnClick;  
            
        }

        private async void ReceiveDataButtonOnClick(object sender, EventArgs eventArgs)
        {
            try
            {
                var weatherData = await this.service.GetWeatherInfo(1234, 1234657);
            }
            catch (Exception exception)
            {

                Console.WriteLine(string.Format("Exception message: {0}", exception.Message));
            }
            

            cityNameData.Text = "Moskau";
            humidityData.Text = "10";
        }
    }
}

