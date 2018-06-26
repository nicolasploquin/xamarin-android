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
using BanqueXA.Model;

namespace BanqueXA.Services
{
    interface IBanqueService
    {
        void create(Client client);
        List<Client> readAll();
        Client read(long id);

    }
}