using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Sample.Dialog
{
    [Activity(Label = "Sample.Dialog", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        Button mDialogSample;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var btnDialogSample = FindViewById<Button>(Resource.Id.btnBaseDialog);
            btnDialogSample.Click += delegate
            {
                Intent intent = new Intent(this,typeof(DialogSampleActivity));
                this.StartActivity(intent);

                this.Finish();
                
            };

        }
    }
}

