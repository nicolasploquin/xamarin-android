using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;

// using Android.Support.V7.App;
// using Android.Support.Design.Widget;

namespace Eni.Banque.Android.Activities
{
    [Activity(
        Label = "@string/main_label",
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.FullSensor
    )]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main_relative);
            //SetContentView(Resource.Layout.activity_main_linear);

            FindViewById<Button>(Resource.Id.main_nav_customers).Click += (sender, e) => {
                StartActivity(typeof(CustomersActivity));
            };
            FindViewById<Button>(Resource.Id.main_nav_customerform).Click += (sender, e) =>
            {
                StartActivity(typeof(CustomerFormActivity));
            };
            FindViewById<Button>(Resource.Id.main_nav_demo).Click += (sender, e) =>
            {
                StartActivity(typeof(DemoActivity));
            };
            //FindViewById<FloatingActionButton>(Resource.Id.main_nav_customerform).Click += (sender, e) => {
            //    StartActivity(typeof(CustomerFormActivity));
            //};


            //var sharedPreferences = GetSharedPreferences("MesPreferences",
            //    Android.Content.FileCreationMode.Private);

            //var sharedPreferencesEditor = sharedPreferences.Edit();
            //sharedPreferencesEditor.PutString("nom", "Leblanc");

            ////sharedPreferencesEditor.PutBoolean("EstActif", true);
            ////sharedPreferencesEditor.PutFloat("MeilleurScore",23441.80f);
            ////sharedPreferencesEditor.PutString("NomDeLApplication","Ma super appli !");
            
            //sharedPreferencesEditor.Commit();
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            this.MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_create:
                    StartActivity(typeof(CustomerFormActivity));
                    return true;
                case Resource.Id.action_customers:
                    StartActivity(typeof(CustomersActivity));
                    return true;
                case Resource.Id.action_prefs:
                    StartActivity(typeof(PrefsActivity));
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

