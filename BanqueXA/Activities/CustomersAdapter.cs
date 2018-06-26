using Android.Views;
using Android.Widget;
using BanqueXA.Model;
using System.Collections.Generic;
using Android.Content;

namespace BanqueXA.Activities
{
    class CustomersAdapter : BaseAdapter<Client>
    {

        List<Client> items;

        public CustomersAdapter(List<Client> data)
        {
            items = data;
        }

        public override Client this[int position] => items[position];

        public override int Count => items.Count;

        public override long GetItemId(int position)
        {
            return items[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = LayoutInflater.From(parent.Context)
                    .Inflate(Resource.Layout.customers_adapter, parent, false);

            Client client = items[position];

            view.FindViewById<TextView>(Resource.Id.customers_adapter_fullname)
                .Text = string.Format(@"{0} {1}", client.Prenom, client.Nom);
            view.FindViewById<TextView>(Resource.Id.customers_adapter_phone)
                .Text = client.Tel;

            return view;
        }
    }

}