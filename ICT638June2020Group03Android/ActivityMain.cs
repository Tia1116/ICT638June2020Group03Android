using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using System;
using Xamarin.Essentials;
using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace ICT638June2020Group03Android
{
    [Activity(Label = "ActivityMain")]
    public class ActivityMain : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            button1.Click += Button1_Click;

            Button button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += Button2_Click;

            Button b3 = FindViewById<Button>(Resource.Id.button3);
            b3.Click += b3_Click;




        }

        private void b3_Click(object sender, EventArgs e)
        {
            //EditText et1 = FindViewById<EditText>(Resource.Id.editText1);
            //TextView tv2 = FindViewById<TextView>(Resource.Id.textView2);



            StartActivity(typeof(photocard));
        }



        private async void Button2_Click(object sender, System.EventArgs e)
        {
            TextView textView1 = FindViewById<TextView>(Resource.Id.textView1);
            TextView address = FindViewById<TextView>(Resource.Id.textView2);
            string text = "Hi, I am interested in the house at" + address.Text + "you have posted for rent. Could I please have more details?";
            string messageText = textView1.Text;

            try
            {
                var message = new SmsMessage(text, address.Text);
                await Sms.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Sms is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        private async void Button1_Click(object sender, System.EventArgs e)
        {

            TextView textView1 = FindViewById<TextView>(Resource.Id.textView1);
            string text = textView1.Text;
            TextView address = FindViewById<TextView>(Resource.Id.textView2);
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = "Hi, I am interested in the house ",
                Title = "Share Text"
            });
        }
    }
}