using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Essentials;

using SQLite;

using Eni.Banque.Android.Model;

namespace Eni.Banque.Android.Services
{
    public class BanqueSqlService : IBanqueAsyncService
    {
        private static BanqueSqlService instance = null;
        public static BanqueSqlService Instance
        {
            get
            {
                if (instance == null)
                    instance = new BanqueSqlService();
                return instance;
            }
        }

        private SQLiteAsyncConnection cnx;

        private readonly string filename = "BanqueDB.db3";

        public BanqueSqlService()
        {
            /* -- remplacé par Xamarin.Essentials --
//#if __ANDROID__
            // Android
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
//#elif __IOS__
            // iOS
            //string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
            //string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder instead
//#endif
            //var path = Path.Combine(libraryPath, filename); // Natif
  */
            var path = Path.Combine(FileSystem.AppDataDirectory, filename); // Essentials

            cnx = new SQLiteAsyncConnection(path);

            // Création de la table ClientData si nécessaire 
            cnx.CreateTableAsync<ClientData>();
            
        }

        public void createAsync(Client client)
        {
            cnx.InsertAsync(ClientData.From(client));
        }

        public async Task<Client> readAsync(long id)
        {
            return ClientData.To(await cnx.GetAsync<ClientData>(id));
        }

        public async Task<List<Client>> readAllAsync()
        {
             return 
                ( await cnx.Table<ClientData>()
                    .OrderBy(cli => cli.Nom)
                    .ToListAsync() )
                    .Select(cli => ClientData.To(cli))
                    .ToList<Client>();
        }

    }
}