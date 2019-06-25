
namespace Eni.Banque.Android.Services
{
    public class ServiceManager
    {
        public static IBanqueAsyncService DataStore = BanqueInMemService.Instance;
    }
}