using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace ICT638June2020Group03Android
{
    [Activity(Label = "navigation")]
    public class Navigation : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView textMessage;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Navigation navigation1 = this;
            Xamarin.Essentials.Platform.Init(navigation1, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView bNavView = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            bNavView.SetOnNavigationItemSelectedListener(this);

        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    //  textMessage.SetText(Resource.String.title_home);
                    return true;
                case Resource.Id.navigation_dashboard:
                    SetContentView(Resource.Layout.activity_main);
                    //textMessage.SetText(Resource.String.title_map);

                    return true;
                case Resource.Id.navigation_notifications:
                    StartActivity(typeof(Map));
                    //textMessage.SetText(Resource.String.title_Items);
                    return true;
            }
            return false;
        }
    }
}