using Android.App;
using Android.OS;
using Android.Content;
using Android.Widget;

using Eni.Banque.Android.Services;
using Eni.Banque.Android.Model;

namespace Eni.Banque.Android.Activities
{
    [Activity(
        Label = "@string/customers_label", 
        ParentActivity = typeof(MainActivity)
    )]
    public class CustomersDefaultActivity : Activity
    {
        private IBanqueAsyncService ds = ServiceManager.DataStore;

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_customers);

            ListView listView = FindViewById<ListView>(Resource.Id.customers_list);

            // Default Array adapter
            //listView.Adapter = new ArrayAdapter<Client>(
            //    this,
            //    Android.Resource.Layout.simple_list_item_1,
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