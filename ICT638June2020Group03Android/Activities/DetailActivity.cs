using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace ICT638June2020Group03Android.Activities
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : Activity
    {
        private EditText fname, lname, Phnum, Adress, Ctr, Mail;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.activity_update_user_details);
            base.OnCreate(savedInstanceState);

            fname = FindViewById<EditText>(Resource.Id.txt_first_name_up);
            lname = FindViewById<EditText>(Resource.Id.txt_last_name_up);
            Phnum = FindViewById<EditText>(Resource.Id.txt_phone_number_up);
            Adress = FindViewById<EditText>(Resource.Id.txt_address_up);
            Ctr = FindViewById<EditText>(Resource.Id.txt_country_up);
            Mail = FindViewById<EditText>(Resource.Id.txt_email_address_up);


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

            fname.Text = user.FirstName;
            lname.Text = user.LastName;
            Phnum.Text = user.PhoneNumber;
            Adress.Text = user.Address;
            Ctr.Text = user.Country;
            Mail.Text = user.EmailAddress;

            Button btn_Share = FindViewById<Button>(Resource.Id.btn_share);
            btn_Share.Click += Btn_Share_Click;

            Button btn_Send = FindViewById<Button>(Resource.Id.btn_send);
            btn_Send.Click += Btn_Send_Click;
        }

        private async void Btn_Send_Click(object sender, EventArgs e)
        {
            string messageText = "";
            string recipient = Phnum.Text;
            try
            {
                var message = new SmsMessage(messageText, new[] { recipient });
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

        private async void Btn_Share_Click(object sender, EventArgs e)
        {
            string text = lname.Text + "\r\n" +
                Mail.Text + Ctr.Text;
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = "Share Text"
            });
        }
    }
}