﻿using System;
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
   public class fragment_agent:Fragment
    {
        
            public override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);

                // Create your fragment here
            }

            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                // Use this to return your custom view for this Fragment
                return inflater.Inflate(Resource.Layout.agent, container, false);

                //return base.OnCreateView(inflater, container, savedInstanceState);
            }
        
    }
}