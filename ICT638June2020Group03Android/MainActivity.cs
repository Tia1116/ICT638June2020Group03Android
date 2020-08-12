using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

using Android.Content;
=======
using Xamarin.Essentials;
using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System.Linq;

namespace ICT638June2020Group03Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);

            Button btn1 = FindViewById<Button>(Resource.Id.button1);
            btn1.Click += Btn1_Click;
        }

        private void Btn1_Click(object sender, System.EventArgs e)
        {

            Intent intent = new Intent();
            intent.SetClass(this, typeof(agent_activity));
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);


    }
}