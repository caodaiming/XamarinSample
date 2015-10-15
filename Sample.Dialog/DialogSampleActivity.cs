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

namespace Sample.Dialog
{
    [Activity(Label = "DialogSampleActivity")]
    public class DialogSampleActivity : Activity
    {
        List<string> _lstDataItem = null;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            InitData();
            // Create your application here
            SetContentView(Resource.Layout.DialogSample);
            var btnBaseDialog = FindViewById<Button>(Resource.Id.btnBaseDialog);
            var btnDialogList = FindViewById<Button>(Resource.Id.btnDialogList);

            btnBaseDialog.Click += delegate {
                var dialog = (new AlertDialog.Builder(this)).Create();
                dialog.SetTitle("Hello World alert dialog");
                dialog.SetButton("OK", handllerNotingButton);
                dialog.SetButton2("Ceancel", handllerNotingButton);
                dialog.SetButton3("Nothing", handllerNotingButton);

                dialog.Show();

            };
            btnDialogList.Click += delegate {
                var dlgAlert = (new AlertDialog.Builder(this)).Create();
                dlgAlert.SetTitle("List View Alert Dialog");
                var listView = new ListView(this);
                listView.Adapter = new AlertDialogListAdapter(this, _lstDataItem);
                listView.ItemClick += listViewItemClick;
                dlgAlert.SetView(listView);
                dlgAlert.SetButton("OK", handllerNotingButton);
                dlgAlert.Show();
            };

        }
        void listViewItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, "you clicked on " + _lstDataItem[e.Position], ToastLength.Short).Show();
        }

        void handllerNotingButton(object sender, DialogClickEventArgs e)
        {
            AlertDialog objAlertDialog = sender as AlertDialog;
            Button btnClicked = objAlertDialog.GetButton(e.Which);
            Toast.MakeText(this, "you cliked on " + btnClicked.Text, ToastLength.Long).Show();
        }

        private void InitData()
        {
            _lstDataItem = new List<string>();
            _lstDataItem.Add("Person 1");
            _lstDataItem.Add("Person 2");
            _lstDataItem.Add("Person 3");
            _lstDataItem.Add("Person 4");
        }
    }
}