using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Sample.ListViewDemo
{
    [Activity(Label = "ListViewDemo",Icon = "@drawable/ax")]
    public class MainActivity : Activity
    {
        private ListView listview = null;
        private List<string> lst;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            lst = new List<string>();
            lst.Add("成都市");
            lst.Add("南充市");
            lst.Add("资阳市");
            lst.Add("绵阳市");
            lst.Add("德阳市");
            lst.Add("资中市");

            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, lst);

            listview = FindViewById<ListView>(Resource.Id.myListView);
            listview.ItemClick += Listview_ItemClick;
            listview.Adapter = adapter;
        }

        private void Listview_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, e.Id.ToString(), ToastLength.Long).Show();
        }
    }
}

