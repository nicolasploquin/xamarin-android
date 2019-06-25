using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Eni.Banque.Android.Model;

namespace Eni.Banque.Android.Services
{
    public interface IBanqueAsyncService
    {
        void createAsync(Client client);
        Task<List<Client>> readAllAsync();
        Task<Client> readAsync(long id);

    }
}