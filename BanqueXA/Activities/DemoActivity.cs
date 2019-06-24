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

namespace BanqueXA.Activities
{
    [Activity(Label = "DemoActivity")]
    public class DemoActivity : Activity
    {
        private TextView lifecycleTextView = null; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_demo);

            lifecycleTextView = FindViewById<TextView>(Resource.Id.demo_activity_lifecycle);

            if(savedInstanceState != null)
            {
                lifecycleTextView.Text += "(" + savedInstanceState.GetString("lifecycle") + ") ";
            }
            lifecycleTextView.Text += "Create - ";

        }

        protected override void OnStart()
        {
            base.OnStart();
            lifecycleTextView.Text += "Start - ";
        }
        protected override void OnRestart()
        {
            base.OnRestart();
            lifecycleTextView.Text += "Restart - ";
        }
        protected override void OnResume()
        {
            base.OnResume();
            lifecycleTextView.Text += "Resume - ";
        }

        protected override void OnPause()
        {
            base.OnPause();
            lifecycleTextView.Text += "Pause - ";
        }

        protected override void OnStop()
        {
            base.OnStop();
            lifecycleTextView.Text += "Stop - ";
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            lifecycleTextView.Text += "Destroy - ";
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutString("lifecycle", lifecycleTextView.Text);
        }

    }
}