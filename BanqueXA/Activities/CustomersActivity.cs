using Android.App;
using Android.OS;
using Android.Content;
//using Android.Support.V7.App;
using Android.Widget;

using Eni.Banque.Android.Services;
using Eni.Banque.Android.Model;

namespace Eni.Banque.Android.Activities
{
    [Activity(
        Label = "@string/customers_label", 
        ParentActivity = typeof(MainActivity)
    )]
    public class CustomersActivity : Activity
    {
        private IBanqueAsyncService ds = ServiceManager.DataStore;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_customers);

            //ActionBar.SetDisplayHomeAsUpEnabled(true);

            ListView listView = FindViewById<ListView>(Resource.Id.customers_list);


            // Array adapter
            //listView.Adapter = new ArrayAdapter<Client>(
            //    this, 
            //    Resource.Id.customer_fullname_adapter,
            //    Resource.Id.customers_adapter_fullname,
            //    (await ds.readAllAsync()).ToArray()
            //    );
            
            // Custom adapter
            //listView.Adapter = new CustomersAdapter(await ds.readAllAsync());
            
            // Custom adapter with recycler view pattern
            listView.Adapter = new CustomersRecyclerAdapter(await ds.readAllAsync());

            listView.ItemClick += (sender, e) =>
            {
                long id = listView.Adapter.GetItemId(e.Position);

                var intent = new Intent(this, typeof(CustomerDetailActivity));
                intent.PutExtra("id", id);

                StartActivity(intent);
            };
            listView.ItemLongClick += (sender, e) =>
            {
                var intent = new Intent(this, typeof(CustomerFormActivity));
                long id = listView.Adapter.GetItemId(e.Position);
                intent.PutExtra("id", id);
                StartActivity(intent);
            };

        }
    }
}