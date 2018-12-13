using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using BanqueXA.Services;

namespace BanqueXA.Activities
{
    [Activity(
        Label = "@string/customers_label", 
        ParentActivity = typeof(MainActivity)
    )]
    public class CustomersActivity : AppCompatActivity
    {
        private IBanqueAsyncService ds = ServiceManager.DataStore;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_customers);

            ListView listView = FindViewById<ListView>(Resource.Id.customers_list);
            listView.Adapter = new CustomersAdapter(await ds.readAllAsync());

            listView.ItemClick += (sender, e) =>
            {
                var intent = new Android.Content.Intent(this, typeof(CustomerDetailActivity));
                long id = ((CustomersAdapter)listView.Adapter)[e.Position].Id;
                intent.PutExtra("id", id);
                StartActivity(intent);
            };
            listView.ItemLongClick += (sender, e) =>
            {
                var intent = new Android.Content.Intent(this, typeof(CustomerFormActivity));
                long id = ((CustomersAdapter)listView.Adapter)[e.Position].Id;
                intent.PutExtra("id", id);
                StartActivity(intent);
            };

        }
    }
}