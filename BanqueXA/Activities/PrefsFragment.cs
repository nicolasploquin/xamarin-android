﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BanqueXA.Activities
{
    [Activity(Label = "@string/prefs_label")]
    public class PrefsActivity : PreferenceActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AddPreferencesFromResource(Resource.Xml.preferences);
            

            //FragmentManager
            //    .BeginTransaction()
            //    .Replace(Android.Resource.Id.Content, new PrefsFragment())
            //    .Commit()
            //    ;

        }

        //private class PrefsFragment : PreferenceFragment
        //{
        //    public override void OnCreate(Bundle savedInstanceState)
        //    {
        //        base.OnCreate(savedInstanceState);

        //        AddPreferencesFromResource(Resource.Xml.preferences);
        //    }
        //}
    }
}