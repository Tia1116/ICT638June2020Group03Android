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

namespace ICT638June2020Group03Android
{
    [Activity(Label = "photocard")]
    public class photocard : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            SetContentView(Resource.Layout.photocard);
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}