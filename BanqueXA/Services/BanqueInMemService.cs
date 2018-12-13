using System.Collections.Generic;
using System.Threading.Tasks;
using BanqueXA.Model;

namespace BanqueXA.Services
{
    public class BanqueInMemService : IBanqueService, IBanqueAsyncService
    {
        private static BanqueInMemService instance = null;
        public static BanqueInMemService Instance {
            get {
                if (instance == null)
                    instance = new BanqueInMemService();
                return instance;
            }
        }

        private static long _id = 0L;

        private List<Client> clients = new List<Client>()
        {
            new Client(){ Id=_id++, Nom="Durand", Prenom="Marie", Tel="0612345789" },
            new Client(){ Id=_id++, Nom="Leblanc", Prenom="Marc", Tel="0623457891" },
            new Client(){ Id=_id++, Nom="Troadec", Prenom="Nolwenn", Tel="0634578912" },
            new Client(){ Id=_id++, Nom="Grenier", Prenom="Laurent", Tel="0645789123" },
            new Client(){ Id=_id++, Nom="Tugdual", Prenom="Lou-Ann", Tel="0657891234" }
        };

        public void create(Client client)
        {
            if (client.Id == 0L) client.Id = _id++;
            else clients.Remove(client);
            clients.Add(client);
        }

        public Client read(long id)
        {
            return clients.Find(cli => cli.Id == id);
        }

        public List<Client> readAll()
        {
            return clients;
        }
        public Task<List<Client>> readAllAsync()
        {
            return Task.FromResult(clients);
        }

        public Task<Client> readAsync(long id)
        {
            return Task.FromResult(read(id));
        }

        public void createAsync(Client client)
        {
            create(client);
        }
    }
}