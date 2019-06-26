using System;
using System.Collections.Generic;

using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Eni.Banque.Android.Model;

namespace Eni.Banque.Android.Activities
{
    class CustomersRecyclerAdapter : BaseAdapter<Client>
    {
        protected List<Client> customers;

        private int inflateCount = 0;

        public CustomersRecyclerAdapter(List<Client> customers)
        {
            this.customers = customers;
        }

        public override Client this[int position] => customers[position];

        public override int Count => customers.Count;

        public override long GetItemId(int position)
        {
            return customers[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            CustomerAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as CustomerAdapterViewHolder;

            if (holder == null)
            {
                Console.WriteLine(@"{0} inflates.\n", ++inflateCount);

                var inflater = parent.Context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
                //var inflater = LayoutInflater.From(parent.Context);

                view = inflater.Inflate(Resource.Layout.customers_adapter, parent, false);

                holder = new CustomerAdapterViewHolder();
                holder.FullName = view.FindViewById<TextView>(Resource.Id.customers_adapter_fullname);
                holder.Phone = view.FindViewById<TextView>(Resource.Id.customers_adapter_phone);

                view.Tag = holder;
            }

            Client customer = customers[position];

            holder.FullName.Text = string.Format(@"{0} {1}", customer.Prenom, customer.Nom);
            holder.Phone.Text = string.Format(@"{0}", customer.Tel);

            return view;
        }
    }

    class CustomerAdapterViewHolder : Java.Lang.Object
    {
        public TextView FullName { get; set; }
        public TextView Phone { get; set; }
    }

}