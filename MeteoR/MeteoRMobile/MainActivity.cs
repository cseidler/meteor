using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MeteoRMobile
{
    [Activity(Label = "MeteoRMobile", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button receiveDataButton = FindViewById<Button>(Resource.Id.receiveData);

            // Get our button from the layout resource,
            // and attach an event to it
            receiveDataButton.Click += (object sender, EventArgs e) =>
            {
                // Translate user’s alphanumeric phone number to numeric
                // receive Data
            };
        }
    }
}

