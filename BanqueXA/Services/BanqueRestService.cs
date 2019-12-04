using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using Eni.Banque.Android.Model;
using Newtonsoft.Json;

namespace Eni.Banque.Android.Services
{
    public class BanqueRestService : IBanqueAsyncService, IAuthService
    {
        private static BanqueRestService instance = null;
        public static BanqueRestService Instance
        {
            get
            {
                if (instance == null)
                    instance = new BanqueRestService();
                return instance;
            }
        }

        private HttpClient http;

        private const string API = "https://banque.azurewebsites.net/api";

        private User user = null;

        public BanqueRestService()
        {
            http = new HttpClient(new Xamarin.Android.Net.AndroidClientHandler());
            
        }

        public async void createAsync(Client client)
        {
            var content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");
            string uri = string.Format(@"{0}/clients/auth", API);
            var response = await http.PostAsync(uri, content);
            //if (! response.IsSuccessStatusCode)
            //{
            //    Toast.MakeText(this, "Authentification requise", ToastLength.Long).Show();
            //}

        }
        

        public async Task<Client> readAsync(long id)
        {
            string uri = string.Format(@"{0}/clients/{1}",API,id);
            var response = await http.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Client>(json);
            }
            return null;
        }

        public async Task<List<Client>> readAllAsync()
        {
            string uri = string.Format(@"{0}/clients", API);
            var response = await http.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Client>>(json);
            }
            return new List<Client>();
        }


        public async Task<User> AuthAsync(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            string uri = string.Format(@"{0}/auth", API);
            var response = http.PostAsync(uri, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(json);

                http.DefaultRequestHeaders.Add("Authorization", string.Format(@"Bearer {0}", user.Token));

                return user;
            }
            return null;
        }

    }
}