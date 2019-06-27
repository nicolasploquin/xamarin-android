using System;
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

namespace Eni.Banque.Android.Activities
{
    [Activity(Label = "@string/prefs_label")]
    public class SettingsActivity : Activity
    {
        EditText defaultName;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ISharedPreferences settings = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor settingsEditor = settings.Edit();

            SetContentView(Resource.Layout.activity_settings);

            defaultName = FindViewById<EditText>(Resource.Id.settings_default_name);
            defaultName.Text = settings.GetString("defaultName", "");
            defaultName.TextChanged += (sender, e) => {
                settingsEditor.PutString("defaultName", defaultName.Text);
                settingsEditor.Commit();
            };
        }

    }
}