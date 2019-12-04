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
using Eni.Banque.Android.Model;
using Eni.Banque.Android.Services;

namespace Eni.Banque.Android.Activities
{
    [Activity(Label = "Authentification", ParentActivity = typeof(MainActivity)) ]
    public class AuthActivity : Activity
    {
        private IAuthService auth = ServiceManager.Authentication;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_auth);

            FindViewById<Button>(Resource.Id.auth_btn_ok).Click +=  async (sender , e) =>
            {
                User user = new User() {
                    Username = FindViewById<EditText>(Resource.Id.auth_username).Text,
                    Password = FindViewById<EditText>(Resource.Id.auth_password).Text
                };
                ;
                if ((await auth.AuthAsync(user)) != null)
                {
                    StartActivity(typeof(CustomerFormActivity));
                }
                else
                {
                    Toast.MakeText(this, "Echec de l'authentification", ToastLength.Long).Show();
                }
            };
    }

    }
}