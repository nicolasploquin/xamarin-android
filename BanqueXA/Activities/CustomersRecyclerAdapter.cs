using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Eni.Banque.Android.Model;

namespace Eni.Banque.Android.Activities
{
    class CustomersRecyclerAdapter : BaseAdapter<Client>, ISectionIndexer
    {
        protected List<Client> customers;

        private int inflateCount = 0;

        public CustomersRecyclerAdapter(List<Client> customers)
        {
            this.customers = customers.OrderBy<Client,string>(c => c.Nom).ToList<Client>();
            UpdateSections();
        }

        public override Client this[int position] => customers[position];

        public override int Count => customers.Count;

        public override long GetItemId(int position)
        {
            return customers[position].Id;
            //return position;
        }

        private string[] sections;

        private void UpdateSections()
        {
            sections = customers
                .Select(c => c.Nom.Substring(0, 1))
                .Distinct()
                .ToArray()
                ;

            Console.WriteLine(sections.Length + " sections");
        }

        public Java.Lang.Object[] GetSections()
        { 
            return sections.Select(s => new Java.Lang.String(s)).ToArray();
        }

        public int GetPositionForSection(int sectionIndex)
        {
            return Array.FindIndex<Client>(
                customers.ToArray(),
                c => c.Nom.Substring(0, 1) == sections[sectionIndex]
            );
        }

        public int GetSectionForPosition(int position)
        {
            return Array.IndexOf(sections, customers[position].Nom.Substring(0, 1));
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