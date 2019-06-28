
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using Android.Support.V4.App;
//using Android.Support.V7.App;
using Android.Widget;
using Eni.Banque.Android.Model;
using Eni.Banque.Android.Services;

namespace Eni.Banque.Android.Activities
{
    [Activity(
        Label = "@string/customerdetail_label",
        ParentActivity = typeof(CustomersActivity)
    )]
    public class CustomerDetailActivity : Activity
    {
        private IBanqueAsyncService ds = ServiceManager.DataStore;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_customer_detail);

            Client client = await ds.readAsync(Intent.GetLongExtra("id", -1));

            // Traitement asynchrone
            // Task<Client> attente = ds.readAsync(Intent.GetLongExtra("id", -1));
            //  attente.ContinueWith(cli =>
            //{
            //    Client client = cli.Result;
            //});

            // Check phone call permission
            ActivityCompat.RequestPermissions(this, new string[] {
                Manifest.Permission.CallPhone
            }, AppPermissions.RequestCallPhonePermissionID);

            FindViewById<TextView>(Resource.Id.customerdetail_lastname).Text = client.Nom;
            FindViewById<TextView>(Resource.Id.customerdetail_firstname).Text = client.Prenom;
            FindViewById<TextView>(Resource.Id.customerdetail_phone).Text = client.Tel;

            FindViewById<Button>(Resource.Id.customerdetail_call).Click += (sender, e) => {
                Intent intent = new Intent(
                    Intent.ActionCall,
                    Uri.Parse(string.Format("tel:{0}", client.Tel))
                );
                StartActivity(intent);

                //PhoneDialer.Open(client.Tel);
            };
            FindViewById<Button>(Resource.Id.customerdetail_edit).Click += (sender, e) => {
                var intent = new Intent(this, typeof(CustomerFormActivity));
                intent.PutExtra("id", client.Id);
                StartActivity(intent);
            };

        }
    }
}