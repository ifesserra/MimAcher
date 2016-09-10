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

namespace MimAcher.Activities.TAB
{
    [Activity(Label = "Aprender", Theme = "@style/Theme.Splash")]
    public class ResultAprenderActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            TextView textview = new TextView(this);
            textview.Text = "Aprender";
            SetContentView(textview);
            
        }
    }
}