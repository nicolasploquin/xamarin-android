using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Widget;
using Android.Content.PM;
using Eni.Banque.Android.Model;
using Eni.Banque.Android.Services;
using Android.Views;

namespace Eni.Banque.Android.Activities
{
    [Activity(
        Label = "@string/customerform_label",
        ParentActivity = typeof(MainActivity),
        ScreenOrientation = ScreenOrientation.FullSensor
    )]
    public class CustomerFormActivity : Activity
    {
        private IBanqueAsyncService ds = ServiceManager.DataStore;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_customer_form);


            ActionBar.SetDisplayHomeAsUpEnabled(true);

            EditText editLastName = FindViewById<EditText>(Resource.Id.clientform_nom);
            EditText editFirstName = FindViewById<EditText>(Resource.Id.clientform_prenom);
            EditText editPhone = FindViewById<EditText>(Resource.Id.clientform_tel);

            Button btnOk = FindViewById<Button>(Resource.Id.customerform_ok);

            Client client;

            

            long id = Intent.GetLongExtra("id", -1);
            if (id != -1)
            {
                client = await ds.readAsync(id);
                editLastName.Text = client.Nom;
                editFirstName.Text = client.Prenom;
                editPhone.Text = client.Tel;
            }
            else
            {
                client = new Client();

                ISharedPreferences settings = PreferenceManager.GetDefaultSharedPreferences(this);
                editLastName.Text = settings.GetString("defaultName", string.Empty);
            }


            btnOk.Click += (sender, e) => {
                Toast.MakeText(this, "Enregistré", ToastLength.Short).Show();

                client = new Client() {
                    Nom = editLastName.Text.Trim(),
                    Prenom = editFirstName.Text.Trim(),
                    Tel = editPhone.Text.Trim()
                };

                ds.createAsync(client);

                Finish();

            };

        }


        // Jamais !!!
        //public override void OnBackPressed() { }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            this.MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            menu.RemoveGroup(Resource.Id.menu_group_main);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_prefs:
                    StartActivity(typeof(SettingsActivity));
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}
