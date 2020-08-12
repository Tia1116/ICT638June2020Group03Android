﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net;
using System.IO;
using System.Text;
using System;
using Newtonsoft.Json;
using ICT638June2020Group03Android.Activities;

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

            Button btn_login = FindViewById<Button>(Resource.Id.btn_login);
            btn_login.Click += Btn_login_Click;

            Button btn_signin = FindViewById<Button>(Resource.Id.btn_register_page);
            btn_signin.Click += Btn_signin_Click;
        }

        private void Btn_signin_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
        }

        private void Btn_login_Click(object sender, System.EventArgs e)
        {
            EditText edEmail = FindViewById<EditText>(Resource.Id.txt_email_address_del);
            EditText edPassword = FindViewById<EditText>(Resource.Id.txt_password_del);

            string url = "https://10.0.2.2:5001/api/Users/1";
            string result = "";
            var httpWebRequest = new HttpWebRequest(new Uri(url));
            httpWebRequest.ServerCertificateValidationCallback = delegate { return true; };
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "Get";



            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            User user = new User();
            user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(result);

            if (edEmail.Text == user.EmailAddress && edPassword.Text == user.Password)
            {
                StartActivity(typeof(DetailActivity));
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}