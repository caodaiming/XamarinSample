using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace Xamarin.Android.Sample.ActionBar
{
    [Activity(Label = "Sample.ActionBar", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Fragment fragment1;
        Fragment fragment2;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            fragment1 = new Fragment();
            
            fragment2 = new Fragment();
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            var tab = ActionBar.NewTab();
            tab.SetText("Tab1");
            tab.SetIcon(Resource.Drawable.Icon);

            var tab2 = ActionBar.NewTab();
            tab2.SetText("Tab2");
            tab2.SetIcon(Resource.Drawable.Icon);

            //ActionBar.AddTab(tab);
            //ActionBar.AddTab(tab2);
            tab.TabSelected += (s, e) =>
                {
                //    if (!fragment1.IsAdded)
                //    {
                //        e.FragmentTransaction.Add(Resource.Id.frameLayout1, fragment1);
                //    }
                //    if (fragment2.IsAdded && !fragment2.IsHidden)
                //    {
                //        e.FragmentTransaction.Hide(fragment2);
                //    }
                    e.FragmentTransaction.Show(fragment1);
                };



            tab2.TabSelected += (s, e) =>
            {
                //if (!fragment2.IsAdded)
                //{
                //    e.FragmentTransaction.Add(Resource.Id.frameLayout1, fragment2);
                //}
                //if (fragment1.IsAdded && !fragment1.IsHidden)
                //{
                //    e.FragmentTransaction.Hide(fragment1);
                //}
                e.FragmentTransaction.Show(fragment2);
            };

            ActionBar.AddTab(tab);
            ActionBar.AddTab(tab2);

            ActionBar.SelectTab(tab);
        }

    }
}