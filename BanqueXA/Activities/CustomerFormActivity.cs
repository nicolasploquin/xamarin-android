using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
//using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using Eni.Banque.Android.Model;
using Eni.Banque.Android.Services;

namespace Eni.Banque.Android.Activities
{
    [Activity(
        Label = "@string/customerform_label",
        ParentActivity = typeof(CustomersActivity),
        ScreenOrientation = ScreenOrientation.FullSensor
    )]
    public class CustomerFormActivity : Activity
    {
        private IBanqueAsyncService ds = ServiceManager.DataStore;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_customer_form);
            

            //ActionBar.SetDisplayHomeAsUpEnabled(true);

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
                    Nom = editLastName.Text,
                    Prenom = editFirstName.Text,
                    Tel = editPhone.Text
                };

                ds.createAsync(client);

                Finish();

            };

        }
    }
}